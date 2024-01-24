using System.ComponentModel.DataAnnotations;

namespace FibergCarRazorPages.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string CustomerName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }
    }
}
