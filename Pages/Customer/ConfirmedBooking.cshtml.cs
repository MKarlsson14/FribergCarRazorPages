using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Customer
{
    public class ConfirmedBookingModel : PageModel
    {
         

        public async Task<IActionResult> OnGetAsync()
        {
        
            return Page();
        }
    }
}
