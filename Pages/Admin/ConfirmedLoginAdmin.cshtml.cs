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

namespace FribergCarRazorPages.Pages.Admin
{
    public class ConfirmedLoginAdminModel : PageModel
    {


        public async Task<IActionResult> OnGetAsync()
        {

            return Page();
        }
    }
}
