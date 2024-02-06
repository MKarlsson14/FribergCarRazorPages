using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Admin
{
    public class IndexModel : PageModel
    {


        public IActionResult OnGet()
        {
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
    }
}
