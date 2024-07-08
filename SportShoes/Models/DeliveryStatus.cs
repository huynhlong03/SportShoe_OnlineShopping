using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportShoes.Models
{
    public class DeliveryStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryStatusID { get; set; }
        [Required]
        [StringLength(150)]
        public string DeliveryStatusName { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
