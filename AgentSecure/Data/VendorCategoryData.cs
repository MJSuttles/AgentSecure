using AgentSecure.Models;

namespace AgentSecure.Data
{
  public class VendorCategoryData
  {
    public static List<VendorCategory> VendorCategories = new()
    {
      // Seed data

      new VendorCategory() { Id = 1, VendorId = 1, CategoryId = 2 }, // Viking Cruises - Cruise
      new VendorCategory() { Id = 2, VendorId = 1, CategoryId = 4 }, // Viking Cruises - Luxury Travel

      new VendorCategory() { Id = 3, VendorId = 2, CategoryId = 3 }, // Delta Vacations - Tour Operator

      new VendorCategory() { Id = 4, VendorId = 3, CategoryId = 4 }, // Sandals Resorts - Luxury Travel
      new VendorCategory() { Id = 5, VendorId = 3, CategoryId = 5 }, // Sandals Resorts - All-Inclusive

      new VendorCategory() { Id = 6, VendorId = 4, CategoryId = 1 }, // Disney Travel Agents - Theme Park

      new VendorCategory() { Id = 7, VendorId = 5, CategoryId = 2 }, // Royal Caribbean - Cruise

      new VendorCategory() { Id = 8, VendorId = 6, CategoryId = 3 }, // Globus Family of Brands - Tour Operator

      new VendorCategory() { Id = 9, VendorId = 7, CategoryId = 6 }, // Travel Impressions - Reseller
      new VendorCategory() { Id = 10, VendorId = 7, CategoryId = 3 }, // Travel Impressions - Tour Operator

      new VendorCategory() { Id = 11, VendorId = 8, CategoryId = 6 }, // Expedia TAAP - Reseller

      new VendorCategory() { Id = 12, VendorId = 9, CategoryId = 6 }, // Apple Vacations - Reseller

      new VendorCategory() { Id = 13, VendorId = 10, CategoryId = 6 }, // AmResorts - Reseller
      new VendorCategory() { Id = 14, VendorId = 10, CategoryId = 4 }  // AmResorts - Luxury Travel
    };
  }
}
