using System.ComponentModel.DataAnnotations;

namespace APIMainProject.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Hotel name is required")]
        [StringLength(100)]
        public string? HotelName { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100)]
        public string? Location { get; set; }

        [Phone]
        [StringLength(15)]
        public string? Contact { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
