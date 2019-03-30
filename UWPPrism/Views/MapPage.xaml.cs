using System;

using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPPrism.Views
{
    public sealed partial class MapPage : Page
    {
        private MapViewModel ViewModel => DataContext as MapViewModel;

        public MapPage()
        {
            InitializeComponent();
        }
    }
}
