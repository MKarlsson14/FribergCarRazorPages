using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using FibergCarRazorPages.ViewModels;

namespace FibergCarRazorPages.Pages.Customer
{
    public class CreateBookingModel : PageModel
    {
        
        private readonly IRepository<Car> carRep;
        private readonly IRepository<Models.Customer> custRep;
        private readonly IRepository<Booking> bookRep;       

        public SelectList Cars { get; set; }
        public SelectList Customers { get; set; }


        public CreateBookingModel(IRepository<Car> carRep,IRepository<Models.Customer> custRep, IRepository<Booking> bookRep)
        {           
            this.carRep = carRep;
            this.custRep = custRep;
            this.bookRep = bookRep;
                       
        }

        public IActionResult OnGet()
        {
           Cars = new SelectList(carRep.GetAll(),nameof(Car.CarId), nameof(Car.Brand));
           Customers = new SelectList(custRep.GetAll(), nameof(Models.Customer.CustomerId), nameof(Models.Customer.CustomerName));          
           return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Booking.Customer = custRep.GetById(Booking.Customer.CustomerId);
            Booking.CustomerId = Booking.Customer.CustomerId;
            Booking.Car = carRep.GetById(Booking.Car.CarId);

            if (Booking.Car == null || Booking.Customer == null || Booking.CustomerId == 0)
            {
                return RedirectToAction(nameof(OnGet));
            }          
               bookRep.Add(Booking);        

            return RedirectToPage("./ConfirmedBooking");
        }
    }
}
