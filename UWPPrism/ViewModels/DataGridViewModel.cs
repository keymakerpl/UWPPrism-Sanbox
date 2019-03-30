﻿using System.Collections.ObjectModel;

using Prism.Windows.Mvvm;

using UWPPrism.Core.Models;
using UWPPrism.Core.Services;

namespace UWPPrism.ViewModels
{
    public class DataGridViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;

        public DataGridViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }

        public ObservableCollection<SampleOrder> Source => _sampleDataService.GetGridSampleData();
    }
}
