using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ColorSizeID { get; set; }
        public ColorSize ColorSize { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
