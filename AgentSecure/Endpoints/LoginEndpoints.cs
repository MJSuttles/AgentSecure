using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;
using System.Text.RegularExpressions;
using AgentSecure.Services;

namespace AgentSecure.Endpoint
{
  public static class LoginEndpoints
  {
    public static void MapLoginEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/logins").WithTags(nameof(Login));

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

      group.MapGet("/reveal-password/{id}", async (int id, IAgentSecureLoginService service) =>
      {
        var password = await service.RevealPasswordByLoginIdAsync(id);
        return password is not null ? Results.Ok(password) : Results.NotFound("Decryption failed.");
      });

      // Get Login by Id
      group.MapGet("/{id}", async (int id, IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.GetLoginByIdAsync(id);
      })
      .WithName("GetLoginById")
      .WithOpenApi()
      .Produces<LoginDto>(StatusCodes.Status200OK);

      group.MapPost("/", async (Login login, IAgentSecureLoginService agentSecureLoginService) =>
    {
      var createdLogin = await agentSecureLoginService.CreateLoginAsync(login);
      return Results.Created($"/api/logins/{createdLogin.Id}", createdLogin);
    })
    .WithName("CreateLogin")
    .WithOpenApi()
    .Produces<LoginDto>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest);


      // Update Login
      group.MapPut("/{id}", async (int id, LoginUpdateDto loginUpdateDto, IAgentSecureLoginService agentSecureLoginService) =>
      {
        return await agentSecureLoginService.UpdateLoginAsync(id, loginUpdateDto);
      })
      .WithName("UpdateLogin")
      .WithOpenApi()
      .Produces<LoginUpdateDto>(StatusCodes.Status200OK)
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

      // Change Password
      // group.MapPost("/change-password", async (ChangePasswordDto changePasswordDto, IAgentSecureLoginService agentSecureLoginService) =>
      // {
      //   var success = await agentSecureLoginService.ChangePasswordAsync(changePasswordDto);

      //   if (success)
      //   {
      //     return Results.Ok(new { message = "Password changed successfully." });
      //   }
      //   else
      //   {
      //     return Results.BadRequest(new { message = "Failed to change password." });
      //   }
      // })
      // .WithName("ChangePassword")
      // .WithOpenApi()
      // .Produces(StatusCodes.Status200OK)
      // .Produces(StatusCodes.Status400BadRequest);

      group.MapPost("/change-password", async (ChangePasswordDto changePasswordDto, IAgentSecureLoginService agentSecureLoginService) =>
      {
        if (changePasswordDto == null)
        {
          return Results.BadRequest(new { message = "DTO binding failed — null payload received." });
        }

        var success = await agentSecureLoginService.ChangePasswordAsync(changePasswordDto);

        return success
          ? Results.Ok(new { message = "Password changed successfully." })
          : Results.BadRequest(new { message = "Failed to change password." });
      });
    }
  }
}
