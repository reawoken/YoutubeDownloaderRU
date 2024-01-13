using YoutubeDownloaderRU.ViewModels.Components;
using YoutubeDownloaderRU.ViewModels.Dialogs;

namespace YoutubeDownloaderRU.ViewModels.Framework;

// Used to instantiate new view models while making use of dependency injection
public interface IViewModelFactory
{
    DashboardViewModel CreateDashboardViewModel();

    DownloadViewModel CreateDownloadViewModel();

    AuthSetupViewModel CreateAuthSetupViewModel();

    DownloadSingleSetupViewModel CreateDownloadSingleSetupViewModel();

    DownloadMultipleSetupViewModel CreateDownloadMultipleSetupViewModel();

    MessageBoxViewModel CreateMessageBoxViewModel();

    SettingsViewModel CreateSettingsViewModel();
}
