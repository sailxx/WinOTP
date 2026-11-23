using System.Security.Cryptography;
using System.Text;
using WinOTP.Models;
using WinOTP.Services;
using WinOTP.Portable;
var root=Path.Combine(Path.GetTempPath(),"winotp-tests-"+Guid.NewGuid());
int checks=0;
void Check(bool ok) {if(!ok)throw new Exception("Assertion failed");checks++;}
void Fails(Action action) {try{action();}catch{checks++;return;}throw new Exception("Expected failure");}
try
{
    using var vault=new PortableVault(root);
    Fails(()=>vault.Save([]));Fails(()=>vault.Create("short"));
    vault.Create("test-password-123");Check(vault.Load().Count==0);
    vault.Lock();vault.Unlock("test-password-123");Check(vault.Load().Count==0);
    var a=new Account {Issuer="RFC",Name="test",Secret="GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ",Digits=8};
    Check(Otp.Generate(a,59)=="94287082");vault.Save([a]);
    Check(!Encoding.UTF8.GetString(File.ReadAllBytes(Path.Combine(root,"vault.enc"))).Contains(a.Secret));
    vault.Lock();Fails(()=>vault.Load());Fails(()=>vault.Unlock("wrong-password"));Check(!vault.IsUnlocked);
    vault.Unlock("test-password-123");Check(vault.Load()[0].Secret==a.Secret);
    using var other=new PortableVault(root);other.Unlock("test-password-123");
    a.Counter=5;vault.Save([a]);Fails(()=>other.Save([]));
    var before=File.ReadAllBytes(Path.Combine(root,"vault.enc"));Fails(()=>vault.Create("another-password"));Check(before.SequenceEqual(File.ReadAllBytes(Path.Combine(root,"vault.enc"))));
    var plain=Encoding.UTF8.GetBytes("Windows compatible backup");var blob=PortableVault.EncryptBackup(plain,"backup-password");
    var key=Rfc2898DeriveBytes.Pbkdf2("backup-password",blob.AsSpan(0,16),600000,HashAlgorithmName.SHA256,32);var decoded=new byte[blob.Length-44];
    using(var aes=new AesGcm(key,16))aes.Decrypt(blob.AsSpan(16,12),blob.AsSpan(44),blob.AsSpan(28,16),decoded);
    Check(plain.SequenceEqual(decoded));Check(plain.SequenceEqual(PortableVault.DecryptBackup(blob,"backup-password")));Fails(()=>PortableVault.DecryptBackup(blob,"wrong"));
    blob[^1]^=1;Fails(()=>PortableVault.DecryptBackup(blob,"backup-password"));
    var tooMany=Enumerable.Range(0,501).Select(i=>new Account {Issuer="test",Secret=a.Secret}).ToList();Fails(()=>vault.Save(tooMany));
    var huge=new Account {Issuer=new string('x',20*1024*1024),Secret=a.Secret};Fails(()=>vault.Save([huge]));Check(vault.Load().Count==1);
    vault.Lock();before[^1]^=1;File.WriteAllBytes(Path.Combine(root,"vault.enc"),before);Fails(()=>vault.Unlock("test-password-123"));Check(!vault.IsUnlocked);
    if(!OperatingSystem.IsWindows())Check((File.GetUnixFileMode(Path.Combine(root,"vault.enc")) & (UnixFileMode.GroupRead|UnixFileMode.OtherRead))==0);
    Console.WriteLine($"Portable storage: {checks} checks passed");
}
finally {Directory.Delete(root,true);}
