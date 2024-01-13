using System.Windows;

namespace YoutubeDownloaderRU.Views.Dialogs;

public partial class SettingsView
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void DarkModeToggleButton_OnChecked(object sender, RoutedEventArgs args) =>
        App.SetDarkTheme();

    private void DarkModeToggleButton_OnUnchecked(object sender, RoutedEventArgs args) =>
        App.SetLightTheme();
}
