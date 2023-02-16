namespace Tabu.Pages;

using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Tabu.ViewModels;

public partial class GamePage : ContentPage
{
    App _application = (App)Application.Current;
    private ProgressArcViewModel _progressArc = new ProgressArcViewModel();
    private DateTime _startTime = DateTime.Now;
    public uint ProgressClickTimes = 0;
    private TimeSpan _pausedElapsedTime;
    CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private bool _isPaused = false;
    private CancellationTokenSource _pauseTokenSource;
    public Utilities utilities = new Utilities();
    private readonly int _duration = Preferences.Get("game_time", 120);
    private double _progress;
    List<bool> paused_history = new List<bool>();
    public string[] lines;
    Random random = new Random();
    public int pass_right = Preferences.Get("pass_right", 3);
    public bool is_exit_confirmed;


    public GamePage()
    {
        InitializeComponent();
        _application.BackgroundAudioView._player.Pause();
        NavigationPage.SetHasNavigationBar(this, false);
        UpdateArc();
        ReadLines();
        if (!utilities.IsDual(_application.Round))
        {
            TeamNameLabel.Text = _application.TeamOne.TeamName;
            CurrentPointLabel.Text = "PUAN: " + _application.TeamOne.CurrentPoints;
        }
        else
        {
            TeamNameLabel.Text = _application.TeamTwo.TeamName;
            CurrentPointLabel.Text = "PUAN: " + _application.TeamTwo.CurrentPoints;
        }
        PassButton.Text = "PAS " + Preferences.Get("pass_right", 3);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ProgressView.Drawable = _progressArc;

    }

    protected override bool OnBackButtonPressed()
    {
        Dispatcher.Dispatch(async () =>
        {
            bool leave = await DisplayAlert("Ana Ekran Dön?", "Oyunu bitirip ana ekrana dönmek istediðinizden emin misiniz?", "Evet", "Hayýr");

            if (leave)
            {
                _application.TeamOne.FullReset();
                _application.TeamTwo.FullReset();
                _application.Round = 1;
                _application.lineDataList.Clear();
                _cancellationTokenSource.Cancel();
                _application._islinesread = false;
                await Navigation.PushAsync(new MainPage());
            }
        });

        return true;
    }
    private async void UpdateArc()
    {
        while (!_cancellationTokenSource.Token.IsCancellationRequested)
        {
            if (_isPaused)
            {

                _pauseTokenSource = new CancellationTokenSource();
                try
                {
                    ProgressButton.Text = "\uE768";
                    await Task.Delay(500, _pauseTokenSource.Token);

                }
                catch (TaskCanceledException)
                {
                    // Do nothing, just continue the loop.
                }

                continue;
            }

            TimeSpan elapsedTime = DateTime.Now - _startTime;
            if (paused_history.Count >= 2)
            {
                if (paused_history[paused_history.Count - 1])
                {
                    elapsedTime = _pausedElapsedTime;
                }

            }

            int secondsRemaining = (int)(_duration - elapsedTime.TotalSeconds);

            ProgressButton.Text = $"{secondsRemaining}";

            _progress = Math.Ceiling(elapsedTime.TotalSeconds);
            _progress %= _duration;
            _progressArc.Progress = _progress / _duration;
            ProgressView.Invalidate();

            if (secondsRemaining == 0)
            {
                _cancellationTokenSource.Cancel();
                RoundOver();
                return;
            }

            await Task.Delay(500);
        }

    }
    private void PauseTimer()
    {
        _isPaused = true;
        _pausedElapsedTime = DateTime.Now - _startTime;
        paused_history.Add(true);
    }

    private void ResumeTimer()
    {
        _isPaused = false;
        _startTime = DateTime.Now - _pausedElapsedTime;
        paused_history.Add(false);
        _pauseTokenSource.Cancel();
    }

    private void ProgressButton_Clicked(object sender, EventArgs e)
    {
        ProgressClickTimes++;
        if (!utilities.IsDual(ProgressClickTimes))
        {
            PauseTimer();

        }
        else
        {
            ResumeTimer();
        }
    }

    private async void ReadLines()
    {
        Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
        Stream stream = await FileSystem.OpenAppPackageFileAsync("sentences.txt");
        using (StreamReader reader = new StreamReader(stream))
        {
            lines = reader.ReadToEnd().Split('\n');
            if (!_application._islinesread)
            {
                GetLinesFromText();
                _application._islinesread = true;
            }
            ChooseWords();
        }
    }
    private void GetLinesFromText()
    {
        for (int line = 0; line < lines.Length; line++)
        {
            string current_line = lines[line];
            char[] seperator = { ',' };
            String[] strlist = current_line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            SentenceDataModel datamodel = new SentenceDataModel();
            datamodel.GuessWord = strlist[0];
            datamodel.TabuWord1 = strlist[1];
            datamodel.TabuWord2 = strlist[2];
            datamodel.TabuWord3 = strlist[3];
            datamodel.TabuWord4 = strlist[4];
            datamodel.TabuWord5 = strlist[5];
            datamodel.IsUsed = false;
            _application.lineDataList.Add(datamodel);
        }
    }
    private void ChooseWords()
    {
        Debug.WriteLine("CHoose word syaty");
        int index = random.Next(_application.lineDataList.Count);
        SentenceDataModel selectedItem = _application.lineDataList[index];
        Debug.WriteLine(selectedItem);
        if (!selectedItem.IsUsed)
        {
            Debug.WriteLine("CHOOSE WORDS INSIDE");
            if (!string.IsNullOrEmpty(selectedItem.GuessWord) && selectedItem != null)
            {
                GuessButon.Text = selectedItem.GuessWord;
                TabuWord1Button.Text = selectedItem.TabuWord1;
                TabuWord2Button.Text = selectedItem.TabuWord2;
                TabuWord3Button.Text = selectedItem.TabuWord3;
                TabuWord4Button.Text = selectedItem.TabuWord4;
                TabuWord5Button.Text = selectedItem.TabuWord5;
                selectedItem.IsUsed = true;
            }
            else
            {
                ChooseWords();
            }

        }
        else
        {
            ChooseWords();
        }
    }

    private void TrueButton_Clicked(object sender, EventArgs e)
    {
        if (!_isPaused)
        {
            if (!utilities.IsDual(_application.Round))
            {
                _application.TeamOne.CurrentPoints++;
                _application.TeamOne.log.Add("true");
                CurrentPointLabel.Text = "PUAN: " + _application.TeamOne.CurrentPoints.ToString();
            }
            else
            {
                _application.TeamTwo.CurrentPoints++;
                _application.TeamTwo.log.Add("true");
                CurrentPointLabel.Text = "PUAN: " + _application.TeamTwo.CurrentPoints.ToString();
            }
            ChooseWords();
        }

    }

    private void TabuButton_Clicked(object sender, EventArgs e)
    {
        if (!_isPaused)
        {
            if (!utilities.IsDual(_application.Round))
            {
                _application.TeamOne.CurrentPoints -= Preferences.Get("tabuu_point", 3);
                CurrentPointLabel.Text = "PUAN: " + _application.TeamOne.CurrentPoints.ToString();
                _application.TeamOne.log.Add("tabu");
            }
            else
            {
                _application.TeamTwo.CurrentPoints -= Preferences.Get("tabuu_point", 3);
                CurrentPointLabel.Text = "PUAN: " + _application.TeamTwo.CurrentPoints.ToString();
                _application.TeamTwo.log.Add("tabu");
            }
            ChooseWords();
        }

    }

    private void PassButton_Clicked(object sender, EventArgs e)
    {
        if (!_isPaused)
        {
            if (pass_right != 0)
            {
                if (!utilities.IsDual(_application.Round))
                {
                    _application.TeamOne.log.Add("pass");
                }
                else
                {
                    _application.TeamTwo.log.Add("pass");
                }
                pass_right -= 1;
                PassButton.Text = "PAS " + pass_right.ToString();
                ChooseWords();
            }

        }


    }
    private void RoundOver()
    {
        Debug.WriteLine(Preferences.Get("winning_point", 75));
        if (!utilities.IsDual(_application.Round))
        {
            _application.TeamOne.ApplyRoundPoints();
            _application.Round++;
            pass_right = Preferences.Get("pass_right", 3);
            if (_application.TeamOne.TotalPoints >= Preferences.Get("winning_point", 75))
            {
                Navigation.PushAsync(new GameOverPage());
            }
            else
            {
                Navigation.PushAsync(new RoundResultsPage());
            }
        }
        else
        {
            _application.TeamTwo.ApplyRoundPoints();
            _application.Round++;
            pass_right = Preferences.Get("pass_right", 3);
            if (_application.TeamTwo.TotalPoints >= Preferences.Get("winning_point", 75))
            {
                Navigation.PushAsync(new GameOverPage());
            }
            else
            {
                Navigation.PushAsync(new RoundResultsPage());
            }

        }

    }
}