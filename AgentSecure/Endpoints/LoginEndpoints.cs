using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;

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
      .Produces<List<LoginDto>>(StatusCodes.Status200OK);

      // Get Logins by User Id
      group.MapGet("/user/{userId}", async (int userId, IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.GetLoginsByUserIdAsync(userId);
      })
      .WithName("GetLoginsByUserId")
      .WithOpenApi()
      .Produces<List<LoginDto>>(StatusCodes.Status200OK);

      // Get Login by Id
      group.MapGet("/{id}", async (int id, IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.GetLoginByIdAsync(id);
      })
      .WithName("GetLoginById")
      .WithOpenApi()
      .Produces<LoginDto>(StatusCodes.Status200OK);

      // Create Login
      group.MapPost("/", async (Login login, IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.CreateLoginAsync(login);
      })
      .WithName("CreateLogin")
      .WithOpenApi()
      .Produces<Login>(StatusCodes.Status201Created)
      .Produces(StatusCodes.Status400BadRequest);

      // Update Login
      group.MapPut("/{id}", async (int id, LoginUpdateDto loginUpdateDto, IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.UpdateLoginAsync(id, loginUpdateDto);
      })
      .WithName("UpdateLogin")
      .WithOpenApi()
      .Produces<Login>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status400BadRequest);

      // Delete Login

      group.MapDelete("/{id}", async (int id, IAgentSecureLoginService agentSecureLoginService) =>
      {
        var deletedLogin = await agentSecureLoginService.DeleteLoginAsync(id);
        if (deletedLogin == null)
        {
          return Results.NotFound($"No Login found for Id {id}.");
        }

        return Results.NoContent();
      })
      .WithName("DeleteLogin")
      .WithOpenApi()
      .Produces<Login>(StatusCodes.Status204NoContent)
      .Produces(StatusCodes.Status404NotFound);
    }
  }
}
