using AgentSecure.Models;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureCategoryService
  {
    // An interface is a contract that defines the signature of the functionality.
    // It defines a set of methods that a class that inherits the interface MUST implement.
    // The interface is a mechanism to achieve abstraction.
    // Interfaces can be used in unit testing to mock out the actual implementation.

    // seed categories
    Task<List<Category>> GetAllCategoriesAsync();
  }
}
