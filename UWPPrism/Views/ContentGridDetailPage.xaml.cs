using System;

using UWPPrism.Core.Models;
using UWPPrism.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPPrism.Views
{
    public sealed partial class ContentGridDetailPage : Page
    {
        public ContentGridDetailPage()
        {
            InitializeComponent();
        }

        private ContentGridDetailViewModel ViewModel => DataContext as ContentGridDetailViewModel;
    }
}
