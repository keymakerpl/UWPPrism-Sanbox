using System;

using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPPrism.Views
{
    public sealed partial class BlankPage : Page
    {
        private BlankViewModel ViewModel => DataContext as BlankViewModel;

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
