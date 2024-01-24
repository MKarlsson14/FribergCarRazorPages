namespace FibergCarRazorPages.Models
{
    public class Booking
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int BookingId { get; set; }
        public Car? Car { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
