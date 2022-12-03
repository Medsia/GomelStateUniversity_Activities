using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface IImageRepository
    {
        Task SaveImageAsync(IFormFile uploadedImage, string path);
        Task EditImageAsync(IFormFile uploadedImage, string path);
        void DeleteImage(string path);
    }
}
