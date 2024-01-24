using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FibergCarRazorPages.Data;
using FibergCarRazorPages.Models;

namespace FribergCarRazorPages.Pages.Admin.Customers
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<FibergCarRazorPages.Models.Customer> custRep;

        public IndexModel(IRepository<FibergCarRazorPages.Models.Customer> custRep)
        {
            this.custRep = custRep;
        }

        public IList<FibergCarRazorPages.Models.Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = custRep.GetAll().ToList<FibergCarRazorPages.Models.Customer>();
        }
    }
}
