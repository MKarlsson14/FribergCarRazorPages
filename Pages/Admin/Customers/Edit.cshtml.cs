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

        public IActionResult OnGet(int id)
        {
            if (id == null || custRep.GetAll() == null)
            {
                return NotFound();
            }

            var customer = custRep.GetById(id);
            //Koll om användaren är inloggad
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {
                if (customer == null)
                {
                    return NotFound();
                }
                Customer = customer;
                return Page();
                
            }
            else
            {
                return RedirectToPage("Admin/Index");
            }    
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (Customer.CustomerId == null || Customer.CustomerName== null || Customer.CustomerPassword == null)
            {
                return Page();
            }

            custRep.Edit(Customer);
            return RedirectToPage("./Index");
        }

        
    }
}
