using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace UWPPrism.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {
        // TODO WTS: Set your default video and image URIs
        private const string DefaultSource = "https://sec.ch9.ms/ch9/db15/43c9fbed-535e-4013-8a4a-a74cc00adb15/C9L12WinTemplateStudio_high.mp4";

        // The poster image is displayed until the video is started
        private const string DefaultPoster = "https://sec.ch9.ms/ch9/db15/43c9fbed-535e-4013-8a4a-a74cc00adb15/C9L12WinTemplateStudio_960.jpg";

        // For more on the MediaPlayer and adjusting controls and behavior see https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/media-playback
        // The DisplayRequest is used to stop the screen dimming while watching for extended periods
        private DisplayRequest _displayRequest = new DisplayRequest();
        private bool _isRequestActive = false;
        private MediaPlayerElement _mpe;

        private IMediaPlaybackSource _source;

        public IMediaPlaybackSource Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }

        private string _posterSource;

        public string PosterSource
        {
            get { return _posterSource; }
            set { SetProperty(ref _posterSource, value); }
        }

        public MediaPlayerViewModel()
        {
            Source = MediaSource.CreateFromUri(new Uri(DefaultSource));
            PosterSource = DefaultPoster;
        }

        public void Initialize(MediaPlayerElement mpe)
        {
            _mpe = mpe;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            _mpe.MediaPlayer.Play();
            _mpe.MediaPlayer.PlaybackSession.PlaybackStateChanged += PlaybackSession_PlaybackStateChanged;
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
            _mpe.MediaPlayer.Pause();
            _mpe.MediaPlayer.PlaybackSession.PlaybackStateChanged -= PlaybackSession_PlaybackStateChanged;
            var mediaSource = Source as MediaSource;
            mediaSource?.Dispose();
            Source = null;
        }

        private async void PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args)
        {
            if (sender is MediaPlaybackSession playbackSession && playbackSession.NaturalVideoHeight != 0)
            {
                if (playbackSession.PlaybackState == MediaPlaybackState.Playing)
                {
                    if (!_isRequestActive)
                    {
                        await _mpe.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            _displayRequest.RequestActive();
                            _isRequestActive = true;
                        });
                    }
                }
                else
                {
                    if (_isRequestActive)
                    {
                        await _mpe.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            _displayRequest.RequestRelease();
                            _isRequestActive = false;
                        });
                    }
                }
            }
        }
    }
}
