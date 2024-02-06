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

namespace FribergCarRazorPages.Pages.Admin.Cars
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Car> carRep;

        public EditModel(IRepository<Car> carRep)
        {
            this.carRep = carRep;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null || carRep.GetAll() == null)
            {
                return NotFound();
            }

            var car = carRep.GetById(id);
            //Koll om användaren är inloggad
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {
                if (car == null)
                {
                    return NotFound();
                }
                Car = car;
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            carRep.Edit(Car);

            return RedirectToPage("./Index");
        }

    }
}
