using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportShoes.Models
{
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorID { get; set; }
        [Required]
        [StringLength(50)]
        public string? ColorName { get; set; }
        [Required]
        [StringLength(50)]
        public string? ColorCode { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
    }
}
