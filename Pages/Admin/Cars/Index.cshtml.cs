using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Admin.Cars
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Car> carRep;

        public IndexModel(IRepository<Car> carRep)
        {
            this.carRep = carRep;
        }

        public IList<Car> Car { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {
                Car = carRep.GetAll().ToList<Car>();
                return Page();
            }
            else
            {
                return RedirectToPage("Admin/Index");
            }

        }
    }
}
