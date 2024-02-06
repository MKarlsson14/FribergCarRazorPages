using System.ComponentModel.DataAnnotations;

namespace FibergCarRazorPages.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        
        public int Price { get; set; }       
        public string? Picture1 { get; set; }
        public string? Picture2 { get; set; }

        public string? FullName { get; set; }

        public Car()
        {
            FullName = $"{Brand} {Model}";
        }
    }
}
