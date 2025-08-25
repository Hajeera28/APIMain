using APIMainProject.Models;
using System.ComponentModel.DataAnnotations;

namespace APIMainProject.DTO
{
    public class OrderDto
    {

        public int? HotelId { get; set; }

        public int? UserId { get; set; }

        public OrderStatus? Status { get; set; }

       
    }
}
