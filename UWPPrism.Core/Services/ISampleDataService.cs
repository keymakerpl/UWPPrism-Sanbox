using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using UWPPrism.Core.Models;

namespace UWPPrism.Core.Services
{
    // This interface specifies methods used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public interface ISampleDataService
    {
        ObservableCollection<DataPoint> GetChartSampleData();
        ObservableCollection<SampleOrder> GetContentGridData();

        ObservableCollection<SampleOrder> GetGridSampleData();
        void Initialize(string localResourcesPath);

        ObservableCollection<SampleImage> GetGallerySampleData();

        Task<IEnumerable<SampleOrder>> GetSampleModelDataAsync();
    }
}
