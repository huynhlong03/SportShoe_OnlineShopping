using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SportShoes.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MaxLength(55)]
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string PhoneNumber { get; set; }
    }
}
