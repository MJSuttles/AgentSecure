using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Endpoint
{
  public static class UserEndpoints
  {
    // The endpoint layer is responsible for handling HTTP requests.
    // The endpoint layer will call the service layer to process business logic.
    // The endpoint layer will return the data to the client.
    // The endpoint layer is the entry point for the client to access the application.
    // We must register this MapWeatherEndpoints method in the Program.cs file.
    // You can click the reference to see where it is registered in the Program.cs file.

    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/users").WithTags(nameof(User));

      // API calls

      group.MapGet("/user/{id}", async (int id, IAgentSecureUserService agentSecureUserService) =>
      {
        var user = await agentSecureUserService.GetUserByIdAsync(id);

        if (user == null)
        {
          return Results.NotFound($"User with ID {id} not found.");
        }

        var profile = new
        {
          user.Id,
          user.Uid,
          user.FirstName,
          user.LastName,
          user.Email,
          user.Phone,
          user.StreetAddress,
          user.City,
          user.State,
          user.Zip
        };

        return Results.Ok(profile);
      })
      .WithName("GetUserById")
      .WithOpenApi()
      .Produces(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status404NotFound);

      group.MapPost("/", async (User user, IAgentSecureUserService agentSecureUserService) =>
      {
        return await agentSecureUserService.CreateUserAsync(user);
      })
      .WithName("CreateUser")
      .WithOpenApi()
      .Produces<User>(StatusCodes.Status201Created)
      .Produces<User>(StatusCodes.Status400BadRequest);
    }
  }
}
