using AgentSecure.Models;

namespace AgentSecure.Interfaces
{
  public interface IAgentSecureUserRepository
  {
    // An interface is a contract that defines the signature of the functionality.
    // It defines a set of methods that a class that inherits the interface MUST implement.
    // The interface is a mechanism to achieve abstraction.
    // Interfaces can be used in unit testing to mock out the actual implementation.

    // seed categories

    Task<User?> GetUserByIdAsync(int id);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(int id, User user);
    Task<User> DeleteUserAsync(int id);
  }
}
