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
        private readonly IHttpContextAccessor cookie;

        public LoginCustomerModel(IRepository<FibergCarRazorPages.Models.Customer> custRep, IHttpContextAccessor cookie)
        {         
            this.custRep = custRep;
            this.cookie = cookie;
        }

        public IActionResult OnGet()
        {
            ViewData["customer"] = Request.Cookies["customer"];
            if (ViewData["customer"] == null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./IndexCustomer");
            }
            
        }

        public IActionResult OnGetLogOut()
        {
            ViewData["customer"] = Request.Cookies["customer"];
            if (ViewData["customer"] != null)
            {
                Response.Cookies.Delete("customer");
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("Index");
            }

        }

        [BindProperty]
        public FibergCarRazorPages.Models.Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
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
                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTimeOffset.UtcNow.AddMinutes(45);
                        cookie.HttpContext.Response.Cookies.Append("customer", custModel.CustomerId.ToString(), options);
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
