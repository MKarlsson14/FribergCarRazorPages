using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Admin.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Booking> bookRep;

        public DeleteModel(IRepository<Booking> bookRep)
        {

            this.bookRep = bookRep;
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
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {
                if (booking == null)
                {
                    return NotFound();
                }
                else
                {
                    Booking = booking;
                }
                return Page();
            }
            else
            {
                return RedirectToPage("Admin/Index");
            }

        }

        public IActionResult OnPost(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookRep.GetById(id);
            if (booking != null)
            {
                Booking = booking;
                bookRep.Delete(Booking);
            }

            return RedirectToPage("./Index");
        }
    }
}
