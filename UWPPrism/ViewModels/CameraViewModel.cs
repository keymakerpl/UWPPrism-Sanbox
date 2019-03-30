using System;
using System.Collections.Generic;
using System.Windows.Input;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using UWPPrism.Controls;
using UWPPrism.EventHandlers;

using Windows.UI.Xaml.Media.Imaging;

namespace UWPPrism.ViewModels
{
    public class CameraViewModel : ViewModelBase
    {
        private ICommand _photoTakenCommand;
        private BitmapImage _photo;
        private CameraControl _cameraControl;

        public BitmapImage Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        public ICommand PhotoTakenCommand => _photoTakenCommand ?? (_photoTakenCommand = new DelegateCommand<CameraControlEventArgs>(OnPhotoTaken));

        private void OnPhotoTaken(CameraControlEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Photo))
            {
                Photo = new BitmapImage(new Uri(args.Photo));
            }
        }

        public void Initialize(CameraControl cameraControl)
        {
            _cameraControl = cameraControl;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            await _cameraControl.InitializeCameraAsync();
        }

        public override async void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
            await _cameraControl.CleanupCameraAsync();
        }
    }
}
