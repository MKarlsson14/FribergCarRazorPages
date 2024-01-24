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

namespace FribergCarRazorPages.Pages.Admin.Customers
{
    public class EditModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public EditModel(IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {
            this.custRep = custRep;
        }

        [BindProperty]
        public FibergCarRazorPages.Models.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || custRep.GetAll() == null)
            {
                return NotFound();
            }

            var customer = custRep.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            custRep.Edit(Customer);
            return RedirectToPage("./Customers/Index");
        }

        
    }
}
