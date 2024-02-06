using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using FibergCarRazorPages.ViewModels;
using FribergCarRazorPages.Data;

namespace FribergCarRazorPages.Pages.Admin.Bookings
{
    public class ListModel : PageModel
    {
        private readonly IBooking bookRep;

        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public ListModel(IBooking bookRep, IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {

            this.bookRep = bookRep;
            this.custRep = custRep;
        }

        public IList<Booking> Booking { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {
                Booking = bookRep.GetAll().ToList<Booking>();
                return Page();
            }
            else
            {
                return RedirectToPage("Admin/Index");
            }



        }
    }
}
