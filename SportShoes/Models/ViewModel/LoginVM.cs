using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models.ViewModel
{
    public class LoginVM
    {
       
        [Required(ErrorMessage = "Nhập username!")]
        public string UserName { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Nhập Password!")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }

    }
}
