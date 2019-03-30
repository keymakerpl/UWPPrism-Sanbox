using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPPrism.Views
{
    public sealed partial class CameraPage : Page
    {
        private CameraViewModel ViewModel => DataContext as CameraViewModel;

        public CameraPage()
        {
            InitializeComponent();
            ViewModel.Initialize(cameraControl);
        }
    }
}
