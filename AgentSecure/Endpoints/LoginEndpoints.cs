using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Endpoint
{
  public static class LoginEndpoints
  {
    // The endpoint layer is responsible for handling HTTP requests.
    // The endpoint layer will call the service layer to process business logic.
    // The endpoint layer will return the data to the client.
    // The endpoint layer is the entry point for the client to access the application.
    // We must register this MapWeatherEndpoints method in the Program.cs file.
    // You can click the reference to see where it is registered in the Program.cs file.

    public static void MapLoginEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/logins").WithTags(nameof(Login));

      // API calls

      // Get All Logins

      group.MapGet("/", async (IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.GetAllLoginsAsync();
      })
      .WithName("GetAllLogins")
      .WithOpenApi()
      .Produces<List<Login>>(StatusCodes.Status200OK);

      // Get Login by Id
      group.MapGet("/{id}", async (int id, IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.GetLoginByIdAsync(id);
      })
      .WithName("GetLoginById")
      .WithOpenApi()
      .Produces<Login>(StatusCodes.Status200OK);

      // Create Login
    }
  }
}
