using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FribergCarRazorPages.Pages.Customer
{
    public class LoginCustomerModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public LoginCustomerModel(IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {         
            this.custRep = custRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FibergCarRazorPages.Models.Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Customer != null && custRep.GetAll() != null)
            {
                var checkCust = custRep.GetAll();
                var custModel = new FibergCarRazorPages.Models.Customer();
                //if(Customer != checkCust.Where(s => s.CustomerName == Customer.CustomerName).Where(x=>x.CustomerPassword == Customer.CustomerPassword))
                //{
                //    custRep.Add(Customer);

                //    Utkommenterad kod här lägger till ny kund i databasen om den ej hittar en kund i databasen.
                //}
                try
                {
                    custModel = checkCust.First(s => s.CustomerName == Customer.CustomerName);
                    if (custModel != null && custModel.CustomerName == Customer.CustomerName && custModel.CustomerPassword == Customer.CustomerPassword)
                    {
                        //redirecta till Login succesfull
                        return RedirectToPage("./ConfirmedLogin");
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
