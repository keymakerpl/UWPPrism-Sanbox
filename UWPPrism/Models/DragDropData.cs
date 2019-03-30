using Windows.ApplicationModel.DataTransfer;

namespace UWPPrism.Models
{
    public class DragDropData
    {
        public DataPackageOperation AcceptedOperation { get; set; }

        public DataPackageView DataView { get; set; }
    }
}
