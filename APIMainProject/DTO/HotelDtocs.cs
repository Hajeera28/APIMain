using System.ComponentModel.DataAnnotations;

namespace APIMainProject.DTO
{
    public class HotelDtocs
    {
       
        public string? HotelName { get; set; }
        public string? Location { get; set; }    
        public string? Contact { get; set; }
        public int Rating { get; set; }
    }
}
