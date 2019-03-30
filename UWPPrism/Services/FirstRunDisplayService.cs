using System;
using System.Threading.Tasks;

using Microsoft.Toolkit.Uwp.Helpers;

using UWPPrism.Views;

namespace UWPPrism.Services
{
    public class FirstRunDisplayService : IFirstRunDisplayService
    {
        private static bool shown = false;

        public async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsFirstRun && !shown)
            {
                shown = true;
                var dialog = new FirstRunDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
