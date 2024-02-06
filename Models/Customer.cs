using System.ComponentModel.DataAnnotations;

namespace FibergCarRazorPages.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string CustomerPassword { get; set; }
    }
}
