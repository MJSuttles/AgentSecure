using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Repositories;
using AgentSecure.DTOs;

namespace AgentSecure.Services
{
  public class AgentSecureLoginService : IAgentSecureLoginService
  {
    // The service layer is responsible for processing business logic.
    // Right now, the service layer is just calling the repository layer.
    // The service layer will call the repository layer to do the actual CRUD operations.
    // The service layer will return the data to the endpoint (controller).

    private readonly IAgentSecureLoginRepository _agentSecureLoginRepository;

    // This constructor is used for dependency injection.
    // We are injecting the ISimplyBooksAuthorRepository interface into the SimplyBooksAuthorRepository class.
    // We inject the repository interface instead of the actual repository class.
    // This is because we can easily mock the interface for unit testing.
    // It also makes our code more flexible and easier to maintain.
    // The type of DI used here is called constructor injection.

    public AgentSecureLoginService(IAgentSecureLoginRepository agentSecureLoginRepository)
    {
      _agentSecureLoginRepository = agentSecureLoginRepository;
    }

    // async means that the method is asynchronous.
    // async methods can be awaited using the await keyword.
    // async methods return a Task or Task<T>.
    // Task represents an asynchronous operation that can return a value.
    // Task<T> is a task that returns a value.
    // To get the value, we use the await keyword.

    // seed data

    public async Task<List<LoginDto>> GetAllLoginsAsync()
    {
      return await _agentSecureLoginRepository.GetAllLoginsAsync();
    }

    public async Task<LoginDto?> GetLoginByIdAsync(int id)
    {
      return await _agentSecureLoginRepository.GetLoginByIdAsync(id);
    }

    public async Task<Login> CreateLoginAsync(Login login)
    {
      return await _agentSecureLoginRepository.CreateLoginAsync(login);
    }

    public async Task<Login> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto)
    {
      return await _agentSecureLoginRepository.UpdateLoginAsync(id, loginUpdateDto);
    }

    public async Task<Login> DeleteLoginAsync(int id)
    {
      return await _agentSecureLoginRepository.DeleteLoginAsync(id);
    }
  }
}
