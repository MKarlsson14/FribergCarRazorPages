using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Admin.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public DetailsModel(IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {
            this.custRep = custRep;
        }


        public FibergCarRazorPages.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = custRep.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
