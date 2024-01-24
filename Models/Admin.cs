using System.ComponentModel.DataAnnotations;

namespace FibergCarRazorPages.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Display(Name = "User")]
        [DataType(DataType.Text)]
        public string AdminName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }

    }
}
