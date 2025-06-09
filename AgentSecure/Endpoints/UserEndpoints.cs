using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Services;
using AgentSecure.DTOs;

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

      // Get All Users

      group.MapGet("/", async (IAgentSecureUserService agentSecureUserService) =>
      {
        var users = await agentSecureUserService.GetAllUsersAsync();
        return Results.Ok(users);
      })
      .WithName("GetAllUsers")
      .WithOpenApi()
      .Produces<List<UserProfileDto>>(StatusCodes.Status200OK);

      // Get User by Id

      group.MapGet("/user/{id}", async (int id, IAgentSecureUserService agentSecureUserService) =>
      {
        var user = await agentSecureUserService.GetUserByIdAsync(id);

        if (user == null)
        {
          return Results.NotFound($"User with ID {id} not found.");
        }

        var profile = new
        {
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
      .Produces<UserProfileDto?>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status404NotFound);

      // Create User

      group.MapPost("/", async (User user, IAgentSecureUserService agentSecureUserService) =>
      {
        return await agentSecureUserService.CreateUserAsync(user);
      })
      .WithName("CreateUser")
      .WithOpenApi()
      .Produces<User>(StatusCodes.Status201Created)
      .Produces<User>(StatusCodes.Status400BadRequest);

      // Update User

      group.MapPut("/{id}", async (int id, UserProfileUpdateDto userProfileUpdateDto, IAgentSecureUserService agentSecureUserService) =>
      {
        var updatedUser = await agentSecureUserService.UpdateUserAsync(id, userProfileUpdateDto);

        if (updatedUser == null)
        {
          return Results.NotFound($"User with ID {id} not found.");
        }
        return Results.Ok(updatedUser);
      })
      .WithName("UpdateUser")
      .WithOpenApi()
      .Produces<UserProfileUpdateDto>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status400BadRequest);

      // Delete User

      group.MapDelete("/{id}", async (int id, IAgentSecureUserService agentSecureUserService) =>
      {
        var deletedUser = await agentSecureUserService.DeleteUserAsync(id);
        if (deletedUser == null)
        {
          return Results.NotFound($"User with ID {id} not found.");
        }

        return Results.NoContent();
      })
      .WithName("DeleteUser")
      .WithOpenApi()
      .Produces<User>(StatusCodes.Status204NoContent)
      .Produces(StatusCodes.Status404NotFound);

      group.MapGet("/uid/{uid}", async (string uid, IAgentSecureUserService userService) =>
      {
        var user = await userService.GetUserByFirebaseUidAsync(uid);
        return user is null ? Results.NotFound() : Results.Ok(user);
      })
      .WithName("GetUserByFirebaseUid")
      .WithOpenApi()
      .Produces<UserWithUidDto>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status404NotFound);
    }
  }
}
