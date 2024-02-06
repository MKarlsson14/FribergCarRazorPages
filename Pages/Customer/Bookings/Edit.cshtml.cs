using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using FribergCarRazorPages.Data;

namespace FribergCarRazorPages.Pages.Customer.Bookings
{
    public class EditModel : PageModel
    {
        private readonly FibergCarRazorPages.Data.ApplicationDbContext _context;
        private readonly IBooking bookRep;
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;
    

        public EditModel(FibergCarRazorPages.Data.ApplicationDbContext context, IBooking bookRep, IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {
            _context = context;
            this.bookRep = bookRep;
            this.custRep = custRep;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookRep.GetById(id);
                //await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
            ViewData["CustomerId"] = new SelectList(custRep.GetAll(), "CustomerId", "CustomerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            ViewData["customer"] = Request.Cookies["customer"];
            int id = Convert.ToInt32(ViewData["customer"]);
            var booking = bookRep.GetById(Booking.BookingId);

            if (ViewData["customer"] != null && booking != null)
            {

                booking.IsActive = 0;
                           
                bookRep.Edit(booking);

                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");

           
        }      
    }
}
