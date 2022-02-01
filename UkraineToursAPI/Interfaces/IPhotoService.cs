using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UkraineToursAPI.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);
        //will add onre more method for deleting the photo
    }
}
