using System.ComponentModel.DataAnnotations;

namespace UkraineToursAPI.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
