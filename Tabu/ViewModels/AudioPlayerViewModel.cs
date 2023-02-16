using Plugin.Maui.Audio;

namespace Tabu.ViewModels
{
    public class AudioPlayerViewModel
    {
        public IAudioPlayer _player;
        public string SelectedSoundFileName;
        public async void AudioFunctions(string MusicFunctions, bool loop = false)
        {
            if (_player == null)
            {
                _player = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(SelectedSoundFileName));
            }
            if (MusicFunctions == "Play")
            {
                _player.Loop = true;
                _player.Play();
            }
            if (MusicFunctions == "Stop")
            {
                _player.Stop();
            }
            if (MusicFunctions == "Dispose")
            {
                _player.Dispose();
            }

        }
        public AudioPlayerViewModel(string filename)
        {
            SelectedSoundFileName = filename;
            AudioFunctions("NaN");
        }
        public bool IsPlaying()
        {
            return _player.IsPlaying;
        }

    }







}
