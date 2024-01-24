using FibergCarRazorPages.Models;
using Microsoft.AspNetCore.Mvc;

namespace FibergCarRazorPages.ViewModels
{
    public class BookingVM
    {
        [BindProperty]
        public Car Car { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        public Booking Booking { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }

    }
}
