﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FibergCarRazorPages.Pages.Home
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
            ViewData["customer"] = Request.Cookies["customer"];
            if (id == null)
            {
                return NotFound();
            }

            var car =  carRep.GetById(id);
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
    }
}
