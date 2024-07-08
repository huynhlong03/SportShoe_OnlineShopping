using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SportShoes.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
       
        public DateTime? OrderDate { get; set; }
        
        public DateTime? DeliveryDate { get; set; }
       
        public string PaymentStatus { get; set; }
        
        public string AspNetUserId { get; set; }
        public ApplicationUser AspNetUser { get; set; }
        public int VoucherID { get; set; }
        public Voucher Voucher { get; set; }
        public double TransportFee { get; set; }
        public int DeliveryStatusID { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        [MaxLength(75)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Address { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(55)]
        public string District { get; set; }
        [MaxLength(55)]
        public string Ward { get; set; }
        public string PhoneNumber { get; set; }
        
        public string? Notes { get; set; }

       
    }
}
