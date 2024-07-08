using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }
        [Required]
        [StringLength(150)]

        public string SupplierName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set;}
        [Required]
        [EmailAddress]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(30)]
        public string Fax { get; set; }
    }
}
