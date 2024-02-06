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
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Car> carRep;

        public DetailsModel(IRepository<Car> carRep)
        {
            this.carRep = carRep;
        }

        public Car Car { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
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
                else
                {
                    Car = car;
                }
                return Page();              
            }
            else
            {
                return RedirectToPage("Admin/Index");
            }

        }
    }
}
