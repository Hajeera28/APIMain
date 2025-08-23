using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMainProject.DTO
{
    public class OrderDetailDto
    {
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
