using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using FribergCarRazorPages.Data;

namespace FribergCarRazorPages.Pages.Customer.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IBooking bookRep;

        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public IndexModel(IBooking bookRep, IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {

            this.bookRep = bookRep;
            this.custRep = custRep;
        }

        public IList<Booking> Booking { get; set; } = default!;

        public void OnGet()
        {
            ViewData["customer"] = Request.Cookies["customer"];
            int id = Convert.ToInt32(ViewData["customer"]);
            if (ViewData["customer"] != null)
            {
                Booking = bookRep.GetAll().Where(s => s.Customer.CustomerId == id).ToList();
                
            }
        }
    }
}
