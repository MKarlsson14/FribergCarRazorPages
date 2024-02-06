using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRazorPages.Data;

namespace FribergCarRazorPages.Pages.Customer.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly FibergCarRazorPages.Data.ApplicationDbContext _context;
        private readonly IBooking bookRep;
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public DeleteModel(FibergCarRazorPages.Data.ApplicationDbContext context, IBooking bookRep, IRepository<FibergCarRazorPages.Models.Customer> custRep)
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
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["customer"] = Request.Cookies["customer"];
            int custId = Convert.ToInt32(ViewData["customer"]);
            var booking = bookRep.GetById(id);

            if (ViewData["customer"] != null && booking != null)
            {
                bookRep.Delete(booking);
                return RedirectToPage("./Index");
            }                    

            return RedirectToPage("./Index");
        }
    }
}
