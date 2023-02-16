namespace Tabu.Pages;

public partial class TeamsPage : ContentPage
{
    App _application = (App)Application.Current;

    public TeamsPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

    }

    private async void TeamsStartBtn_Clicked(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(TeamOneEntry.Text) || String.IsNullOrEmpty(TeamTwoEntry.Text))
        {
            EntrysEmptyWarning.IsVisible = true;
        }
        else
        {
            EntrysEmptyWarning.IsVisible = false;
            _application.TeamOne.TeamName = TeamOneEntry.Text;
            _application.TeamTwo.TeamName = TeamTwoEntry.Text;
            await Navigation.PushAsync(new GamePage());
        }

    }
}