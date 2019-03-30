using System.Threading.Tasks;

using Windows.ApplicationModel.Background;

namespace UWPPrism.Services
{
    internal interface IBackgroundTaskService
    {
        Task RegisterBackgroundTasksAsync();

        void Start(IBackgroundTaskInstance taskInstance);
    }
}
