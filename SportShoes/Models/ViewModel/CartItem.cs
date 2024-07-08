using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models.ViewModel
{
    public class CartItem
    {
        public int ColorSizeID { get; set; }
        public int ProductID { get; set; }
        public string Images { get; set; }
        public string ProductName { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int SizeID { get; set; }
       
        public double? Total => Price * Quantity;
        public int ProductColorId { get; set; }
        public int UserId { get; set; }
        
       
    }
}
