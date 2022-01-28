using System.Threading.Tasks;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Interfaces
{
    public interface IUserRepository
    {
         Task<User> Authenticate(string userName, string password);   
         void Register(string userName, string password); 

         Task<bool> UserAlreadyExists(string userName);
    }
}
