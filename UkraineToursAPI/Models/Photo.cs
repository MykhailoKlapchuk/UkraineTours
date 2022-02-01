using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UkraineToursAPI.Models
{
    [Table("Photos")]
    public class Photo : BaseEntity
    {
        [Required]
        public string PublicId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }

    }
}