using Tabu.Pages;

namespace Tabu;

public partial class MainPage : ContentPage
{
    App _application = (App)Application.Current;
    public MainPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
    protected override bool OnBackButtonPressed()
    {
        // Return true to prevent the back button from navigating back
        return true;
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

