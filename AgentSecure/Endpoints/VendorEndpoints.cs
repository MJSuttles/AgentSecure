using System.Runtime.InteropServices;
using AgentSecure.Interfaces;
using AgentSecure.Models;

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

    public static void MapVendorEndpoints(this IEndpointRouteBuilder routes)
    {
      var group = routes.MapGroup("/api/vendors").WithTags(nameof(Vendor));

      // API calls
    }
  }
}
