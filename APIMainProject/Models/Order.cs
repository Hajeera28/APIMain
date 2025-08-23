using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMainProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        public OrderStatus? Status { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}

