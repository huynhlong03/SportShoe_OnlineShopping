using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class ImportCouponDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImportCouponDetailID { get; set; }
        public int ImportCouponID { get; set; }
        public ImportCoupon ImportCoupon { get; set; }
        public int ColorSizeID { get; set; }
        public ColorSize ColorSize { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
