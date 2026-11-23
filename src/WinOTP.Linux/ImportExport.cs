using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System.Security.Cryptography;
using System.Text.Json;
using WinOTP.Models;
using WinOTP.Services;
using WinOTP.Portable;
namespace WinOTP.Linux;
public sealed partial class MainWindow
{
    private async Task Import()
    {
        if(_locked)return;
        var text=new TextBox {Watermark="otpauth:// or otpauth-migration:// URI",AcceptsReturn=true,MinHeight=90};
        var file=ActionButton("Open backup file…",async()=>
        {
            var selected=await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions {Title="Import backup",AllowMultiple=false});if(selected.Count==0)return;
            await using var stream=await selected[0].OpenReadAsync();if(stream.Length>20*1024*1024)throw new FormatException();using var reader=new StreamReader(stream);text.Text=await reader.ReadToEndAsync();
        });
        var qr=ActionButton("Open QR image…",async()=> {text.Text=await ReadQr()??text.Text;});
        if(!await Confirm("Import accounts",Form(Label("Import an OTP URI, Google migration URI, Aegis JSON or password-encrypted WinOTP backup."),file,qr,text)))return;
        var input=text.Text?.Trim()??"";text.Text="";if(input.Length>20*1024*1024)throw new FormatException();
        List<Account> imported;
        if(input.StartsWith("otpauth://",StringComparison.OrdinalIgnoreCase))imported=[OtpUriParser.Parse(input)];
        else if(input.StartsWith("otpauth-migration://",StringComparison.OrdinalIgnoreCase))imported=MigrationParser.ParseUri(input);
        else if(input.StartsWith("NOIRPASS1:",StringComparison.Ordinal))
        {
            var password=await Password("Backup password");if(password is null)return;
            var plain=PortableVault.DecryptBackup(Convert.FromBase64String(input[10..]),password);
            try{imported=JsonSerializer.Deserialize<List<Account>>(plain)??throw new FormatException();}finally{CryptographicOperations.ZeroMemory(plain);}
        }
        else if(input.StartsWith("NOIRAUTH1:")) {await Message("Windows-only backup","Open this backup on the original Windows account, then export a password-encrypted backup for Linux.");return;}
        else {var password=AegisImporter.RequiresPassword(input)?await Password("Aegis backup password"):null;imported=AegisImporter.Parse(input,password);}
        if(imported.Count is 0 or >500)throw new FormatException();
        var rows=new StackPanel {Spacing=6};var choices=new List<(Account Account,CheckBox Check)>();
        foreach(var a in imported)
        {
            Otp.Validate(a);a.Id=Guid.NewGuid();
            bool duplicate=_accounts.Any(x=>x.Issuer==a.Issuer&&x.Name==a.Name&&SameSecret(x.Secret,a.Secret));
            var check=new CheckBox {Content=$"{a.Issuer} · {a.Name}"+(duplicate?" (already added)":""),IsChecked=!duplicate,IsEnabled=!duplicate};rows.Children.Add(check);choices.Add((a,check));
        }
        if(await Confirm("Review import",rows,"Add selected"))Commit(_accounts.Concat(choices.Where(x=>x.Check.IsChecked==true).Select(x=>x.Account)).ToList());
    }
    private static bool SameSecret(string first,string second)
    {
        var a=Otp.DecodeBase32(first);var b=Otp.DecodeBase32(second);try{return a.AsSpan().SequenceEqual(b);}finally{CryptographicOperations.ZeroMemory(a);CryptographicOperations.ZeroMemory(b);}
    }
    private async Task Backup()
    {
        if(_locked)return;
        var password=await Password("Backup password");if(password is null)return;if(password.Length<8){await Message("Password too short","Use at least 8 characters.");return;}
        var file=await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions {Title="Save encrypted backup",SuggestedFileName=$"WinOTP-backup-{DateTime.Now:yyyy-MM-dd}.winotp",DefaultExtension="winotp"});if(file is null || _locked)return;
        var plain=JsonSerializer.SerializeToUtf8Bytes(_accounts);
        try {var encrypted=PortableVault.EncryptBackup(plain,password);await using var stream=await file.OpenWriteAsync();stream.SetLength(0);await using var writer=new StreamWriter(stream);await writer.WriteAsync("NOIRPASS1:"+Convert.ToBase64String(encrypted));}
        finally {CryptographicOperations.ZeroMemory(plain);}
        await Message("Backup saved","Keep the encrypted file and its password in separate safe places.");
    }
}
