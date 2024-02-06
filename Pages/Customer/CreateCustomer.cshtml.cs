using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Customer
{
    public class CreateCustomerModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public CreateCustomerModel(IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {
            this.custRep = custRep;
        }

        public IActionResult OnGet()
        {
            ViewData["customer"] = Request.Cookies["customer"];
            if (ViewData["customer"] == null)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }

        [BindProperty]
        public FibergCarRazorPages.Models.Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (Customer.CustomerName == null && Customer.CustomerPassword == null)
            {
                return Page();
            }
            custRep.Add(Customer);
            return RedirectToPage("./ConfirmedNewCustomer");
        }
    }
}
