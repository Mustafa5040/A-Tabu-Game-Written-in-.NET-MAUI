using Tabu.ViewModels;

namespace Tabu;

public partial class App : Application
{
    public AudioPlayerViewModel BackgroundAudioView = new AudioPlayerViewModel("BackgroundMusic.mp3");
    public TeamViewModel TeamOne = new TeamViewModel();
    public TeamViewModel TeamTwo = new TeamViewModel();
    public List<SentenceDataModel> lineDataList = new List<SentenceDataModel>();
    public uint Round = 1;
    public bool _islinesread = false;
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
        if (!Preferences.ContainsKey("game_time")) { Preferences.Set("game_time", 120); }
        if (!Preferences.ContainsKey("pass_right")) { Preferences.Set("pass_right", 3); }
        if (!Preferences.ContainsKey("tabuu_point")) { Preferences.Set("tabuu_point", 3); }
        if (!Preferences.ContainsKey("winning_point")) { Preferences.Set("winning_point", 75); }
        if (!Preferences.ContainsKey("background_music_state")) { Preferences.Set("bckground_music_state", false); }

        if (Preferences.Get("background_music_state", false))
        {
            BackgroundAudioView.AudioFunctions("Play", true);
        }
        TeamOne.TeamName = "A TAKIMI";
        TeamTwo.TeamName = "B TAKIMI";

    }
}
