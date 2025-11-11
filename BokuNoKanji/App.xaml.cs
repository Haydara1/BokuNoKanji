using BokuNoKanji.Models;
using BokuNoKanji.ViewModels;

namespace BokuNoKanji;

public partial class App : Application
{
    public static KanjiViewModel SharedKanjiViewModel { get; } = new KanjiViewModel();
    
    public static SearchViewModel SharedSearchViewModel { get; } = new SearchViewModel();

    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();

        // Simple exception handling
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            var exception = (Exception)args.ExceptionObject;
            System.Diagnostics.Debug.WriteLine($"AppDomain UnhandledException: {exception}");
        };

        TaskScheduler.UnobservedTaskException += (sender, args) =>
        {
            System.Diagnostics.Debug.WriteLine($"UnobservedTaskException: {args.Exception}");
            args.SetObserved();
        };
    }
}