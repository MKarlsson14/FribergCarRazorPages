using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Admin.Customers
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public CreateModel(IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {
            this.custRep = custRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FibergCarRazorPages.Models.Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            custRep.Add(Customer);         
            return RedirectToPage("./Index");
        }
    }
}
