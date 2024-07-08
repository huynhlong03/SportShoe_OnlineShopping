using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required]
        [StringLength(250)]

        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Detail { get; set; }
        [Required]
        public int View { get; set; }
        [Required]
        public int Purchares { get; set; }
        [Required]
        public int Reviews { get; set; }
       
        public double? Discount { get; set; }
        [ForeignKey("Categories")]
        public int CategoryID { get; set; }
       
        public virtual Category Category { get; set; }
        [ForeignKey("Brands")]
        public int BrandID { get; set; }
       
        public virtual Brand Brand { get; set; }
        [ForeignKey("Suppliers")]
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }
      
    }
}
