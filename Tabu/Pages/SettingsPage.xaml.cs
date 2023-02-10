namespace Tabu;
public partial class SettingsPage : ContentPage
{

    public SettingsPage()
    {

        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        TimeSlider.Value = Preferences.Get("game_time", 120);
        WinningScoreSlider.Value = Preferences.Get("winning_score", 75);
        PassSlider.Value = Preferences.Get("pass_right", 3);
        TabuSlider.Value = Preferences.Get("tabuu_point", 3);
        BackgroundMusicSwitch.IsToggled = Preferences.Get("background_music_state", true);
    }

    private void TimeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Preferences.Set("game_time", Convert.ToInt32(e.NewValue));
        SettingsTestLabel.Text = e.NewValue.ToString();
    }

    private void WinningScoreSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Preferences.Set("winning_score", Convert.ToInt32(e.NewValue));
        SettingsTestLabel.Text = "Winning Score" + e.NewValue.ToString();
    }

    private void TabuSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Preferences.Set("tabuu_point", Convert.ToInt32(e.NewValue));
        SettingsTestLabel.Text = "tabuu_point" + e.NewValue.ToString();
    }

    private void PassSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Preferences.Set("pass_right", Convert.ToInt32(e.NewValue));
        SettingsTestLabel.Text = "passright" + e.NewValue.ToString();
    }

    private void BackgroundMusicSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        var _application = ((App)Application.Current);
        Preferences.Set("background_music_state", e.Value);

        if (e.Value && !_application.BackgroundAudioView.IsPlaying())
        {
            _application.BackgroundAudioView.AudioFunctions("Play", true);
        }
        else if (!e.Value && _application.BackgroundAudioView.IsPlaying())
        {
            _application.BackgroundAudioView.AudioFunctions("Stop");
        }
    }
}