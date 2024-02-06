using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using FribergCarRazorPages.Pages.Admin.Bookings;

namespace FribergCarRazorPages.Pages.Admin
{
    public class LoginAdminModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;
        private readonly IRepository<FibergCarRazorPages.Models.Admin> adminRep;
        private readonly IRepository<Booking> bookRep;
        private readonly IRepository<Car> carRep;
        private readonly IHttpContextAccessor cookie;

        public LoginAdminModel(IRepository<FibergCarRazorPages.Models.Customer> custRep, IRepository<FibergCarRazorPages.Models.Admin> adminRep, IRepository<FibergCarRazorPages.Models.Booking> bookRep, IRepository<FibergCarRazorPages.Models.Car> carRep, IHttpContextAccessor cookie)
        {
            this.custRep = custRep;
            this.adminRep = adminRep;
            this.bookRep = bookRep;
            this.carRep = carRep;
            this.cookie = cookie;
        }

        public IActionResult OnGet()
        {
            //Koll om användaren är inloggad

            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] == null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./IndexAdmin");
            }

            
        }

        public IActionResult OnGetLogOut()
        {
            ViewData["admin"] = Request.Cookies["admin"];
            if (ViewData["admin"] != null)
            {
                Response.Cookies.Delete("admin");
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("Index");
            }

        }

        [BindProperty]
        public FibergCarRazorPages.Models.Admin Admin { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (Admin != null && adminRep.GetAll() != null)
            {
                var checkAdm = adminRep.GetAll();
                var admModel = new FibergCarRazorPages.Models.Admin();
               
                try
                {
                    //Säkerhetskollar så att användaren finns i systemet.
                    admModel = checkAdm.First(s => s.AdminName == Admin.AdminName);
                    if (admModel != null && admModel.AdminName == Admin.AdminName && admModel.AdminPassword == Admin.AdminPassword)
                    {
                        //Skapar upp cookie för inloggnings session
                 
                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTimeOffset.UtcNow.AddMinutes(45);
                        cookie.HttpContext.Response.Cookies.Append("admin", admModel.AdminId.ToString(), options);


                        //redirecta till Login succesfull
                        return RedirectToPage("./ConfirmedLoginAdmin");
                    }
                }
                catch (Exception)
                {
                    return RedirectToPage("./Index");
                }
               
            }
            return RedirectToPage("./Index");
        }
    }
}
