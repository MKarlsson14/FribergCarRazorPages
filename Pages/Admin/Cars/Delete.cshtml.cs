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
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Car> carRep;

        public DeleteModel(IRepository<Car> carRep)
        {
            this.carRep = carRep;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || carRep.GetAll() == null)
            {
                return NotFound();
            }

            var car = carRep.GetById(id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carRep.GetById(id);
            if (car != null)
            {
                Car = car;
                carRep.Delete(car);             
            }

            return RedirectToPage("./Index");
        }
    }
}
