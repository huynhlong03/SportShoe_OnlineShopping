using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SportShoes.Models;
public class DataContext : IdentityDbContext<ApplicationUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    //public DbSet<ApplicationUser> ApplicationUser { get; set; }
    //public DbSet<ApplicationUser> UserModel { get; set; }

    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<DeliveryStatus> DeliveryStatuses { get; set;}
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ColorSize> ColorSizes { get; set; }
    public DbSet<ImportCoupon> ImportCoupons { get; set; }
   
    public DbSet<Order> Order{ get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ImportCouponDetail> ImportCouponDetails { get; set; }
}
