using System.Security.Cryptography.X509Certificates;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Repositories;
using AgentSecure.DTOs;

namespace AgentSecure.Services
{
  public class AgentSecureUserService : IAgentSecureUserService
  {
    // The service layer is responsible for processing business logic.
    // Right now, the service layer is just calling the repository layer.
    // The service layer will call the repository layer to do the actual CRUD operations.
    // The service layer will return the data to the endpoint (controller).

    private readonly IAgentSecureUserRepository _agentSecureUserRepository;

    // This constructor is used for dependency injection.
    // We are injecting the ISimplyBooksAuthorRepository interface into the SimplyBooksAuthorRepository class.
    // We inject the repository interface instead of the actual repository class.
    // This is because we can easily mock the interface for unit testing.
    // It also makes our code more flexible and easier to maintain.
    // The type of DI used here is called constructor injection.

    public AgentSecureUserService(IAgentSecureUserRepository agentSecureUserRepository)
    {
      _agentSecureUserRepository = agentSecureUserRepository;
    }

    // async means that the method is asynchronous.
    // async methods can be awaited using the await keyword.
    // async methods return a Task or Task<T>.
    // Task represents an asynchronous operation that can return a value.
    // Task<T> is a task that returns a value.
    // To get the value, we use the await keyword.

    // seed data

    public async Task<List<UserProfileDto>> GetAllUsersAsync()
    {
      return await _agentSecureUserRepository.GetAllUsersAsync();
    }

    public async Task<UserProfileDto?> GetUserByIdAsync(int id)
    {
      return await _agentSecureUserRepository.GetUserByIdAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
      return await _agentSecureUserRepository.CreateUserAsync(user);
    }

    public async Task<UserProfileUpdateDto> UpdateUserAsync(int id, UserProfileUpdateDto userProfileUpdateDto)
    {
      return await _agentSecureUserRepository.UpdateUserAsync(id, userProfileUpdateDto);
    }

    public async Task<User> DeleteUserAsync(int id)
    {
      return await _agentSecureUserRepository.DeleteUserAsync(id);
    }

    public async Task<UserWithUidDto?> GetUserByFirebaseUidAsync(string firebaseUid)
    {
      return await _agentSecureUserRepository.GetUserByFirebaseUidAsync(firebaseUid);
    }
  }
}
