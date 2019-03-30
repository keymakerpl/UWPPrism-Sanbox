using System;

using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPPrism.Views
{
    public sealed partial class ContentGridPage : Page
    {
        private ContentGridViewModel ViewModel => DataContext as ContentGridViewModel;

        public ContentGridPage()
        {
            InitializeComponent();
        }
    }
}
