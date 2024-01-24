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
    public class ListModel : PageModel
    {
        private readonly IRepository<Booking> bookRep;

        public ListModel(IRepository<Booking> bookRep)
        {
            
            this.bookRep = bookRep;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = bookRep.GetAll().ToList<Booking>();              
        }
    }
}
