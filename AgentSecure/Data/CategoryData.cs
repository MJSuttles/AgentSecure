using AgentSecure.Models;

namespace AgentSecure.Data
{
  public class CategoryData
  {
    public static List<Category> Categories = new()
    {
      // Seed data

      new Category() { Id = 1, CatName = "Theme Park" },
      new Category() { Id = 2, CatName = "Cruise" },
      new Category() { Id = 3, CatName = "Tour Operator" },
      new Category() { Id = 4, CatName = "Luxury Travel" },
      new Category() { Id = 5, CatName = "All-Inclusive" },
      new Category() { Id = 6, CatName = "Reseller"}
    };
  }
}
