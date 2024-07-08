using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class ImportCoupon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImportCouponID { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime ImportDate { get; set; }
        
        public string? Notes { get; set; }
    }
}
