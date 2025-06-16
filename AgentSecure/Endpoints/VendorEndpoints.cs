using System.Runtime.InteropServices;
using AgentSecure.DTOs;
using AgentSecure.Interfaces;
using AgentSecure.Models;

namespace AgentSecure.Endpoint
{
  public static class VendorEndpoints
  {
    public static void MapVendorEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/vendors").WithTags(nameof(Vendor));

      // ✅ Get All Vendors

      group.MapGet("/", async (IAgentSecureVendorService service) =>
      {
        return await service.GetAllVendorsAsync();
      })
      .WithName("GetAllVendors")
      .WithOpenApi()
      .Produces<List<VendorDto>>(StatusCodes.Status200OK);

      // ✅ Get Vendor by Id

      group.MapGet("/{id}", async (int id, IAgentSecureVendorService service) =>
      {
        var vendor = await service.GetVendorByIdAsync(id);
        return vendor == null
          ? Results.NotFound($"No vendor found for Id {id}.")
          : Results.Ok(vendor);
      })
      .WithName("GetVendorById")
      .WithOpenApi()
      .Produces<VendorDto>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status404NotFound);


      // ✅ Create Vendor

      group.MapPost("/", async (Vendor vendor, IAgentSecureVendorService agentSecureVendorService) =>
      {
        return await agentSecureVendorService.CreateVendorAsync(vendor);
      })
      .WithName("CreateVendor")
      .WithOpenApi()
      .Produces<Vendor>(StatusCodes.Status201Created)
      .Produces(StatusCodes.Status400BadRequest);

      // ✅ Update Vendor

      group.MapPut("/{id}", async (int id, VendorUpdateDto vendorUpdateDto, IAgentSecureVendorService agentSecureVendorService) =>
      {
        return await agentSecureVendorService.UpdateVendorAsync(id, vendorUpdateDto);
      })
      .WithName("UpdateVendor")
      .WithOpenApi()
      .Produces<VendorUpdateDto>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status400BadRequest);

      // ✅ Delete Vendor

      group.MapDelete("/{id}", async (int id, IAgentSecureVendorService agentSecureVendorService) =>
      {
        var deletedVendor = await agentSecureVendorService.DeleteVendorAsync(id);
        if (deletedVendor == null)
        {
          return Results.NotFound($"No vendor found for Id {id}.");
        }

        return Results.NoContent();
      })
      .WithName("DeleteVendor")
      .WithOpenApi()
      .Produces<Vendor>(StatusCodes.Status204NoContent)
      .Produces(StatusCodes.Status404NotFound);
    }
  }
}
