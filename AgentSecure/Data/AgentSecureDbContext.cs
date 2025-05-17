using Microsoft.EntityFrameworkCore;
using AgentSecure.Models;

namespace AgentSecure.Data
{
  public class AgentSecureDbContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<VendorCategory> VendorCategories { get; set; }

    public AgentSecureDbContext(DbContextOptions<AgentSecureDbContext> context) : base(context) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<Category>().HasData(CategoryData.Categories);
      modelBuilder.Entity<Login>().HasData(LoginData.Logins);
      modelBuilder.Entity<User>().HasData(UserData.Users);
      modelBuilder.Entity<Vendor>().HasData(VendorData.Vendors);
      modelBuilder.Entity<VendorCategory>().HasData(VendorCategoryData.VendorCategories);
    }
  }
}
