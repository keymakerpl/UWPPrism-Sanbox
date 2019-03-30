using System;

using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPPrism.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        private ImageGalleryViewModel ViewModel => DataContext as ImageGalleryViewModel;

        public ImageGalleryPage()
        {
            InitializeComponent();
        }
    }
}
