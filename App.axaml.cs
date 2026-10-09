using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Genomix;

public partial class App : Application
{
    private Frontend _frontend;
    private Backend _backend;

    public App()
    {
        _backend = new Backend();
        _frontend = new Frontend(_backend);
    }


    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
           // delegate the creation of the main window to frontend
           _frontend.GenerateMainWindow(desktop);
        }

        base.OnFrameworkInitializationCompleted();
    }
}