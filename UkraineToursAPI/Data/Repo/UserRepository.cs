using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UkraineToursAPI.Dtos;
using UkraineToursAPI.Interfaces;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;
        public UserRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<User> Authenticate(string userName, string passwordText)
        {
            var user =  await dc.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null || user.PasswordKey == null)
                return null;

            if (!MatchPasswordHash(passwordText, user.Password, user.PasswordKey))
                return null;

            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordText));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }            
        }

        public void Register(RegisterReqDto user)
        {
            byte[] passwordHash, passwordKey;

            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            }

            var userToSave = new User
            {
                UserName = user.UserName,
                Password = passwordHash,
                PasswordKey = passwordKey,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            dc.Users.Add(userToSave);
        }

        public async Task<bool> UserAlreadyExists(string userName)
        {
            return await dc.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}
