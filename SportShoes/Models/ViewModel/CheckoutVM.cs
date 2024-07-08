using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models.ViewModel
{
    public class CheckoutVM
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Nhập Tên người nhận!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập Số điện thoại!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Nhập Địa chỉ người nhận!")]
        public string? Address { get; set; }
        public string CityText { get; set; }
        public string DistrictText { get; set; }
        public string WardText { get; set; }
        public string paymentMethod { get; set; }
        public string? Notes { get; set; }
        public int VoucherID { get; set; }
        public List<Voucher> Voucher { get; set; }
    }
}
