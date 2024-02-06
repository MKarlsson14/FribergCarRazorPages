using System;
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
    public class HomeListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Car> carRep;

        public HomeListModel(IRepository<Car> carRep)
        {
            this.carRep = carRep;
        }

        public IList<Car> Car { get; set; } = default!;

        public void OnGet()
        {
            ViewData["customer"] = Request.Cookies["customer"];
            Car = carRep.GetAll().ToList();
        }
    }
}
