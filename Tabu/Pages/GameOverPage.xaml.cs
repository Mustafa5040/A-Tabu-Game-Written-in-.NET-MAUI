namespace Tabu.Pages;

public partial class GameOverPage : ContentPage
{
    App _application = (App)Application.Current;

    public GameOverPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        if (_application.TeamOne.TotalPoints >= Preferences.Get("winning_point", 75))
        {
            if (_application.TeamTwo.TotalPoints >= Preferences.Get("winning_point", 75))
            {
                ResultLabel.Text = "BERABERE";
            }
        }
        else
        {
            ResultLabel.Text = _application.TeamTwo.TeamName + " KAZANDI";
        }
        _application.TeamOne.FullReset();
        _application.TeamTwo.FullReset();
        _application.Round = 1;
    }
    protected override bool OnBackButtonPressed()
    {
        // Return true to prevent the back button from navigating back
        return true;
    }
    private void MainMenuButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}