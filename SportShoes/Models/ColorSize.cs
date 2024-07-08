using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class ColorSize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorSizeID { get; set; }
        public int ProductColorID { get; set; }
        public ProductColor ProductColor { get; set; }
        public int SizeID { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }
        
       
    }
}
