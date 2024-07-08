using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class Size
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeID { get; set; }
        [Required]
        [StringLength(50)]
        public string? SizeName { get; set; }
        public ICollection<ColorSize> ColorSizes { get; set; }
    }
}
