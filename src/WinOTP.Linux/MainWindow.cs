using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using WinOTP.Models;
using WinOTP.Services;
using WinOTP.Portable;

namespace WinOTP.Linux;

public sealed partial class MainWindow : Window
{
    private readonly bool _preview = Environment.GetCommandLineArgs().Contains("--preview");
    private readonly PortableVault _vault;
    private List<Account> _accounts = [];
    private readonly StackPanel _list = new();
    private readonly TextBox _search = new() { Watermark = "Search accounts", MinWidth = 100, Padding = new Thickness(10,8) };
    private readonly Button _show = new() { Content = "Hide codes", MinHeight = 40 };
    private readonly Grid _root = new() { Background = SolidColorBrush.Parse("#202020"), RowDefinitions = new RowDefinitions("32,Auto,*") };
    private readonly Dictionary<Guid, (TextBlock Code, TextBlock Time, ProgressBar? Bar)> _labels = [];
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMilliseconds(500) };
    private Preferences _preferences = new();
    private DateTimeOffset _activity = DateTimeOffset.UtcNow;
    private bool _locked = true;
    private readonly List<Window> _dialogs = [];

    public MainWindow()
    {
        Title = "WinOTP"; Width = 540; Height = 660; MinWidth = 500; MinHeight = 480;
        Background = Brush("#202020"); Foreground = Brush("#FFFFFF");
        SystemDecorations = SystemDecorations.None;
        var previewRoot = Path.Combine(AppContext.BaseDirectory, "preview-data", Environment.ProcessId.ToString());
        _vault = new PortableVault(_preview ? previewRoot : null);
        Content = _root;
        ApplySystemPalette();
        if (PlatformSettings is { } platform) platform.ColorValuesChanged += (_,_) => Avalonia.Threading.Dispatcher.UIThread.Post(ApplySystemPalette);
        BuildHeader();
        _search.Classes.Add("search");
        _search.TextChanged += (_, _) => RenderAccounts();
        _show.Click += async (_, _) => await Guard(async () => { _preferences.HideCodes = !_preferences.HideCodes; SavePreferences(); UpdateCodes(); await Task.CompletedTask; });
        var add = ActionButton("Add", async () => await EditAccount()); add.Classes.Add("primary"); add.Background=Brush("#60DDFF"); add.Foreground=Brush("#06222B"); add.MinHeight = 40;
        var toolbar = new Grid { ColumnDefinitions = new ColumnDefinitions("*,Auto,Auto"), ColumnSpacing = 4 };
        toolbar.Children.Add(_search); toolbar.Children.Add(At(_show, 1)); toolbar.Children.Add(At(add, 2));
        var panel = new Border { Background = Brush("#C03C4148"), BorderBrush = Brush("#30FFFFFF"), BorderThickness = new Thickness(1), CornerRadius = new CornerRadius(14), Padding = new Thickness(4), Child = toolbar };
        var gear = ActionButton("⚙", async () => await Task.CompletedTask);
        gear.HorizontalContentAlignment = HorizontalAlignment.Center; gear.VerticalContentAlignment = VerticalAlignment.Center;
        gear.Width = gear.Height = gear.MinWidth = gear.MinHeight = 32; gear.Padding = new Thickness(0); gear.CornerRadius = new CornerRadius(16);
        gear.Background = Brush("#455460"); gear.Foreground = Brush("#83E7FF"); gear.BorderBrush = Brush("#728895");
        Avalonia.Automation.AutomationProperties.SetName(gear, "Settings");
        var menu = new ContextMenu();
        menu.Items.Add(Menu("Import", Import)); menu.Items.Add(Menu("Backup", Backup)); menu.Items.Add(new Separator()); menu.Items.Add(Menu("Settings", Settings)); menu.Items.Add(Menu("Lock", Lock));
        gear.Click += (_, _) => menu.Open(gear);
        var row = new Grid { ColumnDefinitions = new ColumnDefinitions("*,32"), ColumnSpacing = 8, Margin = new Thickness(16,4,16,4) };
        row.Children.Add(panel); row.Children.Add(At(gear,1)); Grid.SetRow(row,1); _root.Children.Add(row);
        var scroll = new ScrollViewer { Content = _list, Margin = new Thickness(20,0,20,12), VerticalScrollBarVisibility = ScrollBarVisibility.Hidden, HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled };
        Grid.SetRow(scroll,2); _root.Children.Add(scroll);
        AddHandler(PointerPressedEvent, (_, _) => _activity = DateTimeOffset.UtcNow, Avalonia.Interactivity.RoutingStrategies.Tunnel);
        AddHandler(KeyDownEvent, (_, _) => _activity = DateTimeOffset.UtcNow, Avalonia.Interactivity.RoutingStrategies.Tunnel);
        Closed += (_, _) => { _timer.Stop(); _vault.Dispose(); };
        Opened += async (_, _) =>
        {
            if (_preview)
            {
                _locked = false;
                _accounts = [new() { Issuer = "GitHub", Name = "RFC test account", Secret = "GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ" }, new() { Issuer = "Google", Name = "Public test credentials", Secret = "GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ", Favorite = true }, new() { Issuer = "Microsoft", Name = "RFC test account", Secret = "GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ" }];
            }
            else await Guard(Unlock);
            RenderAccounts(); _timer.Start();
            var args = Environment.GetCommandLineArgs(); var index = Array.IndexOf(args,"--screenshot");
            if (_preview && index >= 0 && index + 1 < args.Length)
            {
                await Task.Delay(1200);
                using var image = new RenderTargetBitmap(new PixelSize((int)Width,(int)Height), new Vector(96,96));
                image.Render(_root); image.Save(args[index+1]); Close();
            }
        };
        _timer.Tick += async (_, _) =>
        {
            if (!_locked && !_preview && _preferences.AutoLockMinutes > 0 && DateTimeOffset.UtcNow - _activity >= TimeSpan.FromMinutes(_preferences.AutoLockMinutes)) await Guard(Lock);
            else UpdateCodes();
        };
    }
    private void BuildHeader()
    {
        var header = new Grid { ColumnDefinitions = new ColumnDefinitions("*,Auto,Auto,Auto") };
        var branding = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 8, Margin = new Thickness(16,0,0,0), VerticalAlignment = VerticalAlignment.Center };
        branding.Children.Add(new Image { Source = new Bitmap(AssetLoader.Open(new Uri("avares://WinOTP.Linux/Assets/Logo.png"))), Width = 20, Height = 20 });
        branding.Children.Add(new TextBlock { Text = "WinOTP", FontSize = 13, FontWeight = FontWeight.SemiBold, VerticalAlignment = VerticalAlignment.Center });
        header.Children.Add(branding);
        branding.PointerPressed += (_, e) => { if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed) BeginMoveDrag(e); };
        var min = ActionButton("−", () => { WindowState = WindowState.Minimized; return Task.CompletedTask; });
        var max = ActionButton("□", () => { WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; return Task.CompletedTask; });
        var close = ActionButton("×", () => { Close(); return Task.CompletedTask; });
        var buttons = new[] {min,max,close};
        for (int i=0;i<buttons.Length;i++) { buttons[i].Width=46; buttons[i].MinHeight=32; buttons[i].Height=32; buttons[i].Padding=new Thickness(0); buttons[i].CornerRadius=new CornerRadius(0); header.Children.Add(At(buttons[i],i+1)); }
        _root.Children.Add(header);
    }
    private static T At<T>(T control,int column) where T: Control { Grid.SetColumn(control,column); return control; }
    private static IBrush Brush(string color) => SolidColorBrush.Parse(color);
    private Button ActionButton(string text,Func<Task> action)
    {
        var button = new Button { Content=text, VerticalAlignment=VerticalAlignment.Center };
        button.Click += async (_,_) => await Guard(action); return button;
    }
    private MenuItem Menu(string text,Func<Task> action)
    {
        var item=new MenuItem { Header=text }; item.Click += async (_,_) => await Guard(action); return item;
    }
    private async Task Guard(Func<Task> action)
    {
        try { await action(); }
        catch { await Message("Action failed", "Check the password, file format and access permissions. Existing vault files have not been replaced."); }
    }
    private void RenderAccounts()
    {
        _list.Children.Clear(); _labels.Clear();
        if (_locked) { _list.Children.Add(ActionButton("Unlock vault", Unlock)); return; }
        var query=_search.Text?.Trim() ?? "";
        foreach(var account in _accounts.Where(a=>a.Issuer.Contains(query,StringComparison.OrdinalIgnoreCase)||a.Name.Contains(query,StringComparison.OrdinalIgnoreCase)).OrderByDescending(a=>a.Favorite).ThenBy(a=>a.Issuer).ThenBy(a=>a.Name)) _list.Children.Add(Card(account));
        if (_list.Children.Count==0)
        {
            var empty=new StackPanel { Spacing=8, Margin=new Thickness(0,100,0,0), HorizontalAlignment=HorizontalAlignment.Center };
            empty.Children.Add(new TextBlock {Text=_accounts.Count==0?"Your codes belong here":"No matching accounts",FontSize=20});
            empty.Children.Add(new TextBlock {Text=_accounts.Count==0?"Add an account or import a backup":"Try a different name or service",Foreground=Brush("#C4D4DE"),FontSize=13}); _list.Children.Add(empty);
        }
        UpdateCodes();
    }
    private Border Card(Account account)
    {
        var metadata=new StackPanel {Spacing=5,VerticalAlignment=VerticalAlignment.Center};
        metadata.Children.Add(new TextBlock {Text=account.Issuer,FontSize=16,TextTrimming=TextTrimming.CharacterEllipsis});
        metadata.Children.Add(new TextBlock {Text=account.Name,FontSize=12,Foreground=Brush("#C4D4DE"),TextTrimming=TextTrimming.CharacterEllipsis});
        var actions=new StackPanel {Orientation=Orientation.Horizontal,Spacing=5};
        var star=ActionButton(account.Favorite?"★":"☆",()=> { var updated=CloneAccounts(); updated.Single(a=>a.Id==account.Id).Favorite=!account.Favorite; Commit(updated); return Task.CompletedTask; });
        Avalonia.Automation.AutomationProperties.SetName(star,account.Favorite?"Remove from favorites":"Add to favorites");
        actions.Children.Add(star);
        var more=ActionButton("···",()=>Task.CompletedTask); var menu=new ContextMenu(); menu.Items.Add(Menu("Edit",()=>EditAccount(account))); menu.Items.Add(Menu("Delete",async()=> { if(await Confirm("Delete account?",new TextBlock { Text=$"{account.Issuer} · {account.Name}" },"Delete")) Commit(_accounts.Where(a=>a.Id!=account.Id).ToList()); })); more.Click+=(_,_)=>menu.Open(more); actions.Children.Add(more);
        var top=new Grid {ColumnDefinitions=new ColumnDefinitions("*,Auto"),ColumnSpacing=8}; top.Children.Add(metadata); top.Children.Add(At(actions,1));
        var code=new TextBlock {FontSize=28,Foreground=Brush("#83E7FF")}; var time=new TextBlock {FontSize=10,Foreground=Brush("#B6CAD6")};
        var codes=new StackPanel {Spacing=4}; codes.Children.Add(code);codes.Children.Add(time);
        var copy=ActionButton("Copy code",()=>Copy(account)); var codeRow=new Grid {ColumnDefinitions=new ColumnDefinitions("*,Auto"),ColumnSpacing=16}; codeRow.Children.Add(codes);codeRow.Children.Add(At(copy,1));
        var body=new StackPanel {Spacing=8,Margin=new Thickness(0,14)}; body.Children.Add(top);body.Children.Add(codeRow);
        ProgressBar? bar=null;
        if(account.Type.Equals("TOTP",StringComparison.OrdinalIgnoreCase)) {bar=new ProgressBar {Minimum=0,Maximum=account.Period,Height=4,MinHeight=4};body.Children.Add(bar);}
        _labels[account.Id]=(code,time,bar);
        return new Border {BorderBrush=Brush("#242424"),BorderThickness=new Thickness(0,0,0,1),Child=body};
    }
    private void UpdateCodes()
    {
        _show.Content=_preferences.HideCodes?"Show codes":"Hide codes";
        if(_locked)return;
        foreach(var a in _accounts)
        {
            if(!_labels.TryGetValue(a.Id,out var label))continue;
            label.Code.Text=_preferences.HideCodes?new string('•',a.Digits):Otp.Generate(a);
            var hotp=a.Type.Equals("HOTP",StringComparison.OrdinalIgnoreCase); var remaining=hotp?0:a.Period-DateTimeOffset.UtcNow.ToUnixTimeSeconds()%a.Period;
            label.Time.Text=hotp?"Updated on copy":$"Refreshes in {remaining}s";if(label.Bar is not null) label.Bar.Value=remaining;
        }
    }
    private List<Account> CloneAccounts()=>System.Text.Json.JsonSerializer.Deserialize<List<Account>>(System.Text.Json.JsonSerializer.Serialize(_accounts))!;
    private void Commit(List<Account> accounts) { if(_locked)throw new InvalidOperationException(); if(!_preview)_vault.Save(accounts);_accounts=accounts;RenderAccounts(); }
    private async Task Copy(Account account)
    {
        if(_locked || Clipboard is null)return;
        var code=Otp.Generate(account);
        if(account.Type.Equals("HOTP",StringComparison.OrdinalIgnoreCase)) { if(account.Counter==long.MaxValue)throw new InvalidOperationException();var updated=CloneAccounts();updated.Single(a=>a.Id==account.Id).Counter++;Commit(updated); }
        try { await Clipboard.SetTextAsync(code); }
        catch { await Message("Code not copied","Clipboard is unavailable. A HOTP counter may already have advanced.");return; }
        if(_preferences.ClipboardClearSeconds>0)_=ClearClipboard(code,_preferences.ClipboardClearSeconds);
    }
    private async Task ClearClipboard(string code,int seconds) {await Task.Delay(TimeSpan.FromSeconds(seconds));try{if(Clipboard is not null&&await Avalonia.Input.Platform.ClipboardExtensions.TryGetTextAsync(Clipboard)==code)await Clipboard.ClearAsync();}catch{/* Clipboard may be owned by another process. */}}
}
