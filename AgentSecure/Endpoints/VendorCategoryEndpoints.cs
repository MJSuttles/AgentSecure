using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.Services;

namespace AgentSecure.Endpoint
{
  public static class VendorCategoryEndpoints
  {


    public static void MapVendorCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/vendorcategories").WithTags(nameof(VendorCategory));

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

      group.MapDelete("/{id}", async (int id, IAgentSecureVendorCategoryService agentSecureVendorCategoryService) =>
      {
        var deletedVendorCategory = await agentSecureVendorCategoryService.DeleteVendorCategoryAsync(id);
        if (deletedVendorCategory == null)
        {
          return Results.NotFound($"No VendorCategory found for Id {id}.");
        }

        return Results.NoContent();
      })
      .WithName("DeleteVendorCategory")
      .WithOpenApi()
      .Produces(StatusCodes.Status204NoContent)
      .Produces(StatusCodes.Status404NotFound);
    }
  }
}
