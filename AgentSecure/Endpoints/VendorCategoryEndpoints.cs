using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Services;

namespace AgentSecure.Endpoint
{
  public static class VendorCategoryEndpoints
  {
    // The endpoint layer is responsible for handling HTTP requests.
    // The endpoint layer will call the service layer to process business logic.
    // The endpoint layer will return the data to the client.
    // The endpoint layer is the entry point for the client to access the application.
    // We must register this MapWeatherEndpoints method in the Program.cs file.
    // You can click the reference to see where it is registered in the Program.cs file.

    public static void MapVendorCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/vendorcategories").WithTags(nameof(VendorCategory));

      // API calls

      // Create VendorCategory
      group.MapPost("/", async (VendorCategory vendorCategory, IAgentSecureVendorCategoryService agentSecureVendorCategoryService) =>
      {
        return await agentSecureVendorCategoryService.CreateVendorCategoryAsync(vendorCategory);
      })
      .WithName("CreateVendorCategory")
      .WithOpenApi()
      .Produces<VendorCategory>(StatusCodes.Status201Created)
      .Produces(StatusCodes.Status400BadRequest);

      // Delete VendorCategory


    }
  }
}
