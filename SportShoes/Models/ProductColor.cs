using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SportShoes.Models.ViewModel;

namespace SportShoes.Models
{
    public class ProductColor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductColorID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; } // Navigation property

        public int ColorID { get; set; }
        public Color Color { get; set; } // Navigation property
        [Required]
      
        public string Images { get; set; }
        [Required]
        public string Sub_Images1 { get; set; }
        [Required]
        public string Sub_Images2 { get; set; }
        [Required]
        public string Sub_Images3 { get; set; }
        [Required]
        public string Sub_Images4 { get; set; }

        
        public ICollection<ColorSize> ColorSizes { get; set; }
        
    }
}
