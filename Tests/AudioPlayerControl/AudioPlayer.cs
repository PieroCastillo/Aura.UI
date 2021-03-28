using System;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using SharpAudio;
using SharpAudio.Codec;

[assembly: XmlnsDefinition("https://github.com/avaloniaui", "AudioPlayerControl")]

namespace AudioPlayerControl
{
    [PseudoClasses(":paused", ":playing", ":extended")]
    public class AudioPlayer : TemplatedControl
    {
        private float _volume;
        private string _path;
        private AudioPlayerState _currentState;
        private TimeSpan _currentTime;
        private TimeSpan _durationTime;
        private AudioEngine engine;
        private SoundStream soundStream;

        public AudioPlayer()
        {
            PseudoClasses.Add(":paused");
        }

        //~AudioPlayer()
        //{
        //    if (engine != null & soundStream != null)
        //    {
        //        engine.Dispose();
        //        soundStream.Dispose();
        //    }
        //}

        static AudioPlayer()
        {
            PathProperty.Changed.Subscribe(PathChangedStc);
        }

        private static void PathChangedStc(AvaloniaPropertyChangedEventArgs<string> e)
        {
            var control = e.Sender as AudioPlayer;
            control.Load();
        }

        public void Load()
        {
            if (Path != null & File.Exists(Path))
            {
                Debug.WriteLine("Path exist");
                engine = AudioEngine.CreateDefault();
                soundStream = new SoundStream(File.OpenRead(Path), engine);
                Debug.WriteLine("Loaded correctly");
                return;
            }
        }

        private void ChangeVolume(float new_volume)
        {
            if (soundStream != null)
                soundStream.Volume = new_volume;
        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            switch (this.CurrentState)
            {
                case AudioPlayerState.Paused:
                    Play();
                    break;

                case AudioPlayerState.Playing:
                    Pause();
                    break;
            }
        }

        public void Play()
        {
            if (soundStream != null)
                soundStream.Play();

            PseudoClasses.Remove(":paused");
            PseudoClasses.Add(":playing");
        }

        public void Pause()
        {
            if (soundStream != null)
                soundStream.Play();

            PseudoClasses.Remove(":playing");
            PseudoClasses.Add(":paused");
        }

        public void Stop()
        {
            if (soundStream != null)
                soundStream.Stop();

            PseudoClasses.Remove(":playing");
            PseudoClasses.Add(":paused");
        }

        #region Properties

        public float Volume
        {
            get => _volume;
            set
            {
                ChangeVolume(value);
                SetAndRaise(VolumeProperty, ref _volume, value);
            }
        }

        public string Path
        {
            get => _path;
            set
            {
                SetAndRaise(PathProperty, ref _path, value);
            }
        }

        public AudioPlayerState CurrentState
        {
            get => _currentState;
            private set => SetAndRaise(CurrentStateProperty, ref _currentState, value);
        }

        public TimeSpan CurrentTime
        {
            get => _currentTime;
            private set => SetAndRaise(CurrentTimeProperty, ref _currentTime, value);
        }

        public TimeSpan DurationTime
        {
            get => _durationTime;
            private set => SetAndRaise(DurationTimeProperty, ref _durationTime, value);
        }

        #endregion Properties

        #region Static Fields

        //direct properties
        public readonly static DirectProperty<AudioPlayer, float> VolumeProperty =
            AvaloniaProperty.RegisterDirect<AudioPlayer, float>(nameof(Volume), o => o.Volume, (o, v) => o.Volume = v, unsetValue: 10);

        public readonly static DirectProperty<AudioPlayer, string> PathProperty =
            AvaloniaProperty.RegisterDirect<AudioPlayer, string>(nameof(PathProperty), o => o.Path, (o, v) => o.Path = v);

        //readonly properties
        public readonly static DirectProperty<AudioPlayer, AudioPlayerState> CurrentStateProperty =
            AvaloniaProperty.RegisterDirect<AudioPlayer, AudioPlayerState>(nameof(CurrentState), o => o.CurrentState);

        public readonly static DirectProperty<AudioPlayer, TimeSpan> CurrentTimeProperty =
            AvaloniaProperty.RegisterDirect<AudioPlayer, TimeSpan>(nameof(CurrentTime), o => o.CurrentTime);

        public static readonly DirectProperty<AudioPlayer, TimeSpan> DurationTimeProperty =
            AvaloniaProperty.RegisterDirect<AudioPlayer, TimeSpan>(nameof(DurationTime), o => o.DurationTime);

        #endregion Static Fields
    }

        [Serializable]
        [Flags]
    public enum AudioPlayerState
    {
        Paused,
        Playing
    }
}

