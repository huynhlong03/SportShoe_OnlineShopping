using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportShoes.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(150)]
        public string CategoryName { get; set; }
        [Required]
       
        public string? Icon { get; set; }
        [Required]
        
        public string? Description { get; set; }
    }
}
