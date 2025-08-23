using APIMainProject.Models;
using System.ComponentModel.DataAnnotations;

namespace APIMainProject.DTO
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }

      
        public DateTime OrderTime { get; set; }

       
        public OrderStatus? Status { get; set; }
    }
}
