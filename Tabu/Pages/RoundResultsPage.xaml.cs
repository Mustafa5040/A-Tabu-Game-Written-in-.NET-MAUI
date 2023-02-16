using Tabu.ViewModels;

namespace Tabu.Pages;

public partial class RoundResultsPage : ContentPage
{
    App _application = (App)Application.Current;
    public Utilities utilities = new Utilities();
    public RoundResultsPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        TeamOneNameLabelScores.Text = _application.TeamOne.TeamName;
        TeamTwoNameLabelScores.Text = _application.TeamTwo.TeamName;
        TeamOneScoreButtonScores.Text = _application.TeamOne.TotalPoints.ToString();
        TeamTwoScoreButtonScores.Text = _application.TeamTwo.TotalPoints.ToString();
        RoundAbstractButton.Text = (_application.Round - 1).ToString() + ". TUR";

        if (!utilities.IsDual(_application.Round - 1))
        {
            TrueAbstractButton.Text = _application.TeamOne.log.FindAll(i => i == "true").Count.ToString();
            TabuAbstractButton.Text = _application.TeamOne.log.FindAll(i => i == "tabu").Count.ToString();
            CurrentAbstractButton.Text = _application.TeamOne.CurrentPoints.ToString();
            _application.TeamOne.CurrentReset();
        }
        else
        {
            TrueAbstractButton.Text = _application.TeamTwo.log.FindAll(i => i == "true").Count.ToString();
            TabuAbstractButton.Text = _application.TeamTwo.log.FindAll(i => i == "tabu").Count.ToString();
            CurrentAbstractButton.Text = _application.TeamTwo.CurrentPoints.ToString();
            _application.TeamTwo.CurrentReset();
        }

    }

    protected override bool OnBackButtonPressed()
    {
        // Return true to prevent the back button from navigating back
        return true;
    }

    private void ContinueGameButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GamePage());
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        _application.BackgroundAudioView._player.Play();
        _application.TeamOne.FullReset();
        _application.TeamTwo.FullReset();
        _application.Round = 1;
        Navigation.PushAsync(new MainPage());
    }
}