using Plugin.Maui.Audio;
using System.Diagnostics;
using Tabu.Pages;
using Tabu.ViewModels;

namespace Tabu;

public partial class MainPage : ContentPage
{
    App _application = (App)Application.Current;
    public MainPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
    private void AboutButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AboutPage());
    }

    private void HowToPlayButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HowToPlayPage());
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SettingsPage());
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TeamsPage());

    }
}

