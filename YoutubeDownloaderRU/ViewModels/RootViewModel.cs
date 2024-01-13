using System;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using Stylet;
using YoutubeDownloaderRU.Services;
using YoutubeDownloaderRU.Utils;
using YoutubeDownloaderRU.ViewModels.Components;
using YoutubeDownloaderRU.ViewModels.Dialogs;
using YoutubeDownloaderRU.ViewModels.Framework;

namespace YoutubeDownloaderRU.ViewModels;

public class RootViewModel : Screen
{
    private readonly IViewModelFactory _viewModelFactory;
    private readonly DialogManager _dialogManager;
    private readonly SettingsService _settingsService;

    public SnackbarMessageQueue Notifications { get; } = new(TimeSpan.FromSeconds(5));

    public DashboardViewModel Dashboard { get; }

    public RootViewModel(
        IViewModelFactory viewModelFactory,
        DialogManager dialogManager,
        SettingsService settingsService
    )
    {
        _viewModelFactory = viewModelFactory;
        _dialogManager = dialogManager;
        _settingsService = settingsService;

        Dashboard = _viewModelFactory.CreateDashboardViewModel();

        DisplayName = $"{App.Name} v{App.VersionString}";
    }

    protected override void OnViewLoaded()
    {
        base.OnViewLoaded();

        _settingsService.Load();

        // Sync the theme with settings
        if (_settingsService.IsDarkModeEnabled)
        {
            App.SetDarkTheme();
        }
        else
        {
            App.SetLightTheme();
        }
    }

    protected override void OnClose()
    {
        base.OnClose();

        Dashboard.CancelAllDownloads();

        _settingsService.Save();
    }
}
