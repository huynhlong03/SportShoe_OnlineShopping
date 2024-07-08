using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace SportShoes.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string District { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string Ward { get; set; }
        [Required(ErrorMessage = "Không để trống!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Không để trống!"), EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]

        public string Password { get; set; }
        public string? Role { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
