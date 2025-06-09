using Microsoft.EntityFrameworkCore;
using AgentSecure.Models;
using Microsoft.AspNetCore.Mvc;

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

      // Make Uid unique in the Users table
      modelBuilder.Entity<User>()
        .HasIndex(u => u.Uid)
        .IsUnique();

      // Explicitly define the primary key for VendorCategory
      modelBuilder.Entity<VendorCategory>()
        .HasKey(vc => vc.Id);

      // Login => User (many-to-one)
      modelBuilder.Entity<Login>()
        .HasOne(l => l.User)
        .WithMany(u => u.Logins)
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      // Login => Vendor (many-to-one)
      modelBuilder.Entity<Login>()
        .HasOne(l => l.Vendor)
        .WithMany(v => v.Logins)
        .HasForeignKey(l => l.VendorId)
        .OnDelete(DeleteBehavior.Cascade);

      // VendorCategory => Vendor (many-to-one)
      modelBuilder.Entity<VendorCategory>()
        .HasOne(vc => vc.Vendor)
        .WithMany(v => v.VendorCategories)
        .HasForeignKey(vc => vc.VendorId)
        .OnDelete(DeleteBehavior.Cascade);

      // VendorCateogry => Category (many-to-one)
      modelBuilder.Entity<VendorCategory>()
        .HasOne(vc => vc.Category)
        .WithMany(c => c.VendorCategories)
        .HasForeignKey(vc => vc.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Category>().HasData(CategoryData.Categories);
      modelBuilder.Entity<Login>().HasData(LoginData.Logins);
      modelBuilder.Entity<User>().HasData(UserData.Users);
      modelBuilder.Entity<Vendor>().HasData(VendorData.Vendors);
      modelBuilder.Entity<VendorCategory>().HasData(VendorCategoryData.VendorCategories);
    }
  }
}
