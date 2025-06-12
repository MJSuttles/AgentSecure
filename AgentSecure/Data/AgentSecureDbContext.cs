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

    public AgentSecureDbContext(DbContextOptions<AgentSecureDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Unique constraint on Firebase UID
      modelBuilder.Entity<User>()
        .HasIndex(u => u.Uid)
        .IsUnique();

      // Primary key for VendorCategory
      modelBuilder.Entity<VendorCategory>()
        .HasKey(vc => vc.Id);

      // Relationships
      modelBuilder.Entity<Login>()
        .HasOne(l => l.User)
        .WithMany(u => u.Logins)
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Login>()
        .HasOne(l => l.Vendor)
        .WithMany(v => v.Logins)
        .HasForeignKey(l => l.VendorId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<VendorCategory>()
        .HasOne(vc => vc.Vendor)
        .WithMany(v => v.VendorCategories)
        .HasForeignKey(vc => vc.VendorId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<VendorCategory>()
        .HasOne(vc => vc.Category)
        .WithMany(c => c.VendorCategories)
        .HasForeignKey(vc => vc.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);

      // Seed data (Users, Vendors, Categories, etc.)
      modelBuilder.Entity<Category>().HasData(CategoryData.Categories);
      modelBuilder.Entity<User>().HasData(UserData.Users);
      modelBuilder.Entity<Vendor>().HasData(VendorData.Vendors);
      modelBuilder.Entity<VendorCategory>().HasData(VendorCategoryData.VendorCategories);

      // Important: Logins should only be seeded if the data includes hashed password + salt
      modelBuilder.Entity<Login>().HasData(LoginData.GetEncryptedLogins());

    }
  }
}
