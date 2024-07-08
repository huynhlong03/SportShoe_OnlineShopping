using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandID { get; set; }
        [Required]
        [StringLength(150)]
        public string BrandName { get; set; }
        [Required]
        public string? Note { get; set; }
    }
}
