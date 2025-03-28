using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using webLaptopTest.Data.Base;

namespace webLaptopTest.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
