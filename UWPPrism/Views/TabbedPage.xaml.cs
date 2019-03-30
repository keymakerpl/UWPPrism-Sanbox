using System;

using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPPrism.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel => DataContext as TabbedViewModel;

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
