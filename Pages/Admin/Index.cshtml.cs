using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Admin
{
    public class LoginAdminModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;
        private readonly IRepository<FibergCarRazorPages.Models.Admin> adminRep;
        private readonly IRepository<Booking> bookRep;
        private readonly IRepository<Car> carRep;

        public LoginAdminModel(IRepository<FibergCarRazorPages.Models.Customer> custRep, IRepository<FibergCarRazorPages.Models.Admin> adminRep, IRepository<FibergCarRazorPages.Models.Booking> bookRep, IRepository<FibergCarRazorPages.Models.Car> carRep)
        {
            this.custRep = custRep;
            this.adminRep = adminRep;
            this.bookRep = bookRep;
            this.carRep = carRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FibergCarRazorPages.Models.Admin Admin { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Admin != null && adminRep.GetAll() != null)
            {
                var checkAdm = adminRep.GetAll();
                var admModel = new FibergCarRazorPages.Models.Admin();
                try
                {
                    admModel = checkAdm.First(s => s.AdminName == Admin.AdminName);
                    if (admModel != null && admModel.AdminName == Admin.AdminName && admModel.AdminPassword == Admin.AdminPassword)
                    {
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
