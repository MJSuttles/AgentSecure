using AgentSecure.Models;

namespace AgentSecure.Data
{
  public class UserData
  {
    public static List<User> Users = new()
    {
      // Seed data

    new User() { Id = 1, Uid = "-Nabc123XYZ7890user1", FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", Phone = "555-123-4567", StreetAddress = "123 Elm Street", City = "Nashville", State = "TN", Zip = "37201" },
    new User() { Id = 2, Uid = "-Ndef456LMN4567user2", FirstName = "Bob", LastName = "Martinez", Email = "bob.martinez@example.com", Phone = "555-987-6543", StreetAddress = "456 Oak Avenue", City = "Atlanta", State = "GA", Zip = "30301" }
    };
  }
}
