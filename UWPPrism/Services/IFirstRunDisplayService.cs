using System.Threading.Tasks;

namespace UWPPrism.Services
{
    public interface IFirstRunDisplayService
    {
        Task ShowIfAppropriateAsync();
    }
}
