using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using System.Text.Json;
using WinOTP.Models;
using WinOTP.Services;
namespace WinOTP.Linux;
public sealed partial class MainWindow
{
    private sealed class Preferences
    {
        public bool HideCodes { get; set; }
        public int ClipboardClearSeconds { get; set; } = 30;
        public int AutoLockMinutes { get; set; } = 5;
    }
    private void SavePreferences()
    {
        if (_preview) return;
        Directory.CreateDirectory(_vault.Root);
        File.WriteAllText(Path.Combine(_vault.Root,"preferences.json"),JsonSerializer.Serialize(_preferences));
    }
    private static TextBox Input(string value="", bool password=false) => new() {Text=value,PasswordChar=password?'●':'\0',MinWidth=300};
    private static StackPanel Form(params Control[] controls) {var p=new StackPanel {Spacing=10};foreach(var c in controls)p.Children.Add(c);return p;}
    private static TextBlock Label(string text)=>new() {Text=text,TextWrapping=Avalonia.Media.TextWrapping.Wrap};
    private async Task<bool> Confirm(string title,Control content,string accept="Continue")
    {
        var dialog=new Window {Title=title,Width=430,MaxHeight=620,SizeToContent=SizeToContent.Height,CanResize=false,WindowStartupLocation=WindowStartupLocation.CenterOwner};
        var yes=new Button {Content=accept};yes.Classes.Add("primary");var no=new Button {Content="Cancel"};
        yes.Click+=(_,_)=>dialog.Close(true);no.Click+=(_,_)=>dialog.Close(false);
        var buttons=Form(no,yes);buttons.Orientation=Orientation.Horizontal;buttons.HorizontalAlignment=HorizontalAlignment.Right;
        dialog.Content=new Border {Padding=new Thickness(20),Child=Form(new TextBlock {Text=title,FontSize=20},new ScrollViewer {Content=content,MaxHeight=450},buttons)};
        dialog.AddHandler(PointerPressedEvent,(_,_)=>_activity=DateTimeOffset.UtcNow,Avalonia.Interactivity.RoutingStrategies.Tunnel);
        dialog.AddHandler(KeyDownEvent,(_,_)=>_activity=DateTimeOffset.UtcNow,Avalonia.Interactivity.RoutingStrategies.Tunnel);
        _dialogs.Add(dialog);
        try { return await dialog.ShowDialog<bool>(this); }
        finally { _dialogs.Remove(dialog); }
    }
    private async Task Message(string title,string text)=>await Confirm(title,Label(text),"OK");
    private async Task<string?> Password(string title)
    {
        var box=Input(password:true);return await Confirm(title,Form(Label("Password"),box))?box.Text:null;
    }
    private async Task Unlock()
    {
        if(!_locked)return;
        var exists=_vault.Exists;
        var pass=Input(password:true);var repeat=Input(password:true);
        if(!await Confirm(exists?"Unlock vault":"Create encrypted vault",exists?Form(Label("Master password"),pass):Form(Label("Use at least 8 characters. Keep this password safe: it cannot be recovered."),pass,Label("Confirm password"),repeat),exists?"Unlock":"Create"))return;
        if(!exists && pass.Text!=repeat.Text) {await Message("Passwords do not match","Try again.");return;}
        if(exists)_vault.Unlock(pass.Text??"");else _vault.Create(pass.Text??"");
        _accounts=_vault.Load();_locked=false;_activity=DateTimeOffset.UtcNow;
        var path=Path.Combine(_vault.Root,"preferences.json");
        try {if(File.Exists(path))_preferences=JsonSerializer.Deserialize<Preferences>(File.ReadAllText(path))??new();}catch { _preferences=new(); }
        RenderAccounts();
    }
    private Task Lock() {if(_preview)return Task.CompletedTask;_locked=true;foreach(var dialog in _dialogs.ToArray())dialog.Close(false);_vault.Lock();_accounts=[];RenderAccounts();return Task.CompletedTask;}
    private async Task EditAccount(Account? old=null)
    {
        if(_locked)return;
        var issuer=Input(old?.Issuer??"");var name=Input(old?.Name??"");var secret=Input(old?.Secret??"",true);
        var algorithm=new ComboBox {ItemsSource=new[]{"SHA1","SHA256","SHA512"},SelectedItem=old?.Algorithm??"SHA1"};
        var digits=new ComboBox {ItemsSource=new[]{6,8},SelectedItem=old?.Digits??6};
        var type=new ComboBox {ItemsSource=new[]{"TOTP","HOTP"},SelectedItem=old?.Type??"TOTP"};
        var period=Input((old?.Period??30).ToString());var counter=Input((old?.Counter??0).ToString());
        if(!await Confirm(old is null?"Add account":"Edit account",Form(Label("Service"),issuer,Label("Account / email"),name,Label("Secret key (Base32)"),secret,Label("Algorithm"),algorithm,Label("Digits"),digits,Label("Type"),type,Label("Period (TOTP)"),period,Label("Counter (HOTP)"),counter),"Save"))return;
        var a=new Account {Id=old?.Id??Guid.NewGuid(),Issuer=issuer.Text?.Trim()??"",Name=name.Text?.Trim()??"",Secret=secret.Text?.Trim()??"",Algorithm=(string)algorithm.SelectedItem!,Digits=(int)digits.SelectedItem!,Type=(string)type.SelectedItem!,Period=int.Parse(period.Text!),Counter=long.Parse(counter.Text!),Favorite=old?.Favorite??false};
        Otp.Validate(a);if(a.Issuer.Length==0)throw new FormatException();
        var updated=CloneAccounts();if(old is null)updated.Add(a);else updated[updated.FindIndex(x=>x.Id==old.Id)]=a;Commit(updated);secret.Text="";
    }
    private async Task Settings()
    {
        if(_locked)return;
        var hide=new CheckBox {Content="Hide OTP codes",IsChecked=_preferences.HideCodes};
        var clear=new ComboBox {ItemsSource=new[]{0,15,30,60},SelectedItem=_preferences.ClipboardClearSeconds};
        var idle=new ComboBox {ItemsSource=new[]{0,1,5,10,15},SelectedItem=_preferences.AutoLockMinutes};
        if(!await Confirm("Settings",Form(hide,Label("Clear clipboard after seconds (0 = never)"),clear,Label("Lock after minutes (0 = never)"),idle,Label("The master password encrypts your Linux vault. Export an encrypted backup before moving to another device."),Label("Version 0.4.0")),"Save"))return;
        _preferences.HideCodes=hide.IsChecked==true;_preferences.ClipboardClearSeconds=(int)clear.SelectedItem!;_preferences.AutoLockMinutes=(int)idle.SelectedItem!;SavePreferences();UpdateCodes();
    }
}
