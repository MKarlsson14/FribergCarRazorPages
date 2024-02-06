using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using FribergCarRazorPages.Data;

namespace FribergCarRazorPages.Pages.Admin.Cars
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Car> carRep;

        public CreateModel(IRepository<Car> carRep)
        {
            this.carRep = carRep;
        }

        public IActionResult OnGet()
        {
            //Koll om användaren är inloggad
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {

                return Page();
            }
            else
            {
                return RedirectToPage("Admin/Index");
            }
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            carRep.Add(Car);           
            return RedirectToPage("./Index");
        }
    }
}
