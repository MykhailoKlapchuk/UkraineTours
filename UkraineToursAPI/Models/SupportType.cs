using System.ComponentModel.DataAnnotations;

namespace UkraineToursAPI.Models
{
    public class SupportType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}