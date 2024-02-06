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
    public class IndexModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public IndexModel(IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {
            this.custRep = custRep;
        }

        public IList<FibergCarRazorPages.Models.Customer> Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            //Koll om användaren är inloggad
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {
                Customer = custRep.GetAll().ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("Admin/Index");
            }

        }
    }
}
