using System;

using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPPrism.Views
{
    public sealed partial class MediaPlayerPage : Page
    {
        private MediaPlayerViewModel ViewModel => DataContext as MediaPlayerViewModel;

        public MediaPlayerPage()
        {
            InitializeComponent();
            ViewModel.Initialize(mpe);
        }
    }
}
