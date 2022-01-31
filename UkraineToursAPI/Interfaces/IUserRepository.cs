using System.Threading.Tasks;
using UkraineToursAPI.Dtos;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Interfaces
{
    public interface IUserRepository
    {
         Task<User> Authenticate(string userName, string password);   
         void Register(RegisterReqDto user); 

         Task<bool> UserAlreadyExists(string userName);
    }
}
