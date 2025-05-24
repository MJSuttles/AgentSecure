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
      group.MapGet("/", async (IAgentSecureVendorService agentSecureVendorService) =>
      {
        return await agentSecureVendorService.GetAllVendorsAsync();
      })
      .WithName("GetAllVendors")
      .WithOpenApi()
      .Produces<List<Vendor>>(StatusCodes.Status200OK);

      // ✅ Get Vendor by Id
      group.MapGet("/{id}", async (int id, IAgentSecureVendorService agentSecureVendorService) =>
      {
        var vendor = await agentSecureVendorService.GetVendorByIdAsync(id);

        if (vendor == null)
        {
          return Results.NotFound($"No vendor found for Id {id}.");
        }

        var dto = new VendorDto
        {
          Id = vendor.Id,
          Name = vendor.Name,
          Website = vendor.Website,
          LoginWebsite = vendor.LoginWebsite,
          Phone = vendor.Phone,
          Consortium = vendor.Consortium,
          Description = vendor.Description,
          Categories = vendor.VendorCategories != null
            ? vendor.VendorCategories
                .Where(vc => vc != null && vc.Category != null)
                .Select(vc => vc.Category.CatName)
                .ToList()
            : new List<string>()
        };

        return Results.Ok(dto);
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
      group.MapPut("/{id}", async (int id, Vendor vendor, IAgentSecureVendorService agentSecureVendorService) =>
      {
        return await agentSecureVendorService.UpdateVendorAsync(id, vendor);
      })
      .WithName("UpdateVendor")
      .WithOpenApi()
      .Produces<Vendor>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status400BadRequest);


    }
  }
}
