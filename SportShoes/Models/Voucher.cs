using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class Voucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoucherID { get; set; }
        [Required]
        [StringLength(50)]
        public string VoucherName { get; set; }
        [Required]
        [StringLength(20)]
        public string VoucherCode { get; set; }

        public double Discount { get; set; }
        public double MinOrderAmount { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
