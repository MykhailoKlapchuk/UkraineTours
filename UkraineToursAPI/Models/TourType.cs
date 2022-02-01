using System.ComponentModel.DataAnnotations;

namespace UkraineToursAPI.Models
{
    public class TourType: BaseEntity
    {        
        [Required]
        public string Name { get; set; }
    }
}