using AgentSecure.Models;

namespace AgentSecure.Data
{
  public class VendorData
  {
    public static List<Vendor> Vendors = new()
    {
      // Seed data

      new Vendor() { Id = 1, Name = "Viking Cruises", Website = "https://www.vikingcruises.com", LoginWebsite = "https://www.vikingtravelagents.com", Phone = "800-706-1483", Consortium = "", Description = "Luxury river and ocean cruise line known for cultural experiences." },
      new Vendor() { Id = 2, Name = "Delta Vacations", Website = "https://www.delta.com/vacations", LoginWebsite = "www.vaxvacationaccess.com", Phone = "800-727-1111", Consortium = "VAX Vacation Access", Description = "Air and hotel vacation packages powered by Delta Air Lines." },
      new Vendor() { Id = 3, Name = "Sandals Resorts", Website = "https://www.sandals.com", LoginWebsite = "https://taportal.sandals.com", Phone = "888-726-3257", Consortium = "", Description = "All-inclusive Caribbean resorts for couples." },
      new Vendor() { Id = 4, Name = "Disney Travel Agents", Website = "https://www.disneytravelagents.com", LoginWebsite = "https://www.disneytravelagents.com", Phone = "877-569-3276", Consortium = "", Description = "Booking site and resources for Disney Destinations travel professionals." },
      new Vendor() { Id = 5, Name = "Royal Caribbean", Website = "https://www.royalcaribbean.com", LoginWebsite = "https://www.cruisingpower.com", Phone = "800-327-2056", Consortium = "Cruising Power", Description = "Popular cruise line with innovative ships and global destinations." },
      new Vendor() { Id = 6, Name = "Globus Family of Brands", Website = "https://www.globusjourneys.com", LoginWebsite = "https://www.globusfamily.com/TravelAgents", Phone = "866-755-8581", Consortium = "", Description = "Tour operator offering guided land tours and independent travel." },
      new Vendor() { Id = 7, Name = "Travel Impressions", Website = "https://www.travelimpressions.com", LoginWebsite = "https://www.vaxvacationaccess.com", Phone = "800-284-0044", Consortium = "", Description = "Luxury vacation wholesaler with access to top resorts worldwide." },
      new Vendor() { Id = 8, Name = "Expedia TAAP", Website = "https://www.expedia.com", LoginWebsite = "https://www.expediataap.com", Phone = "866-310-5768", Consortium = "", Description = "Travel agent affiliate program offering hotels, flights, and packages." },
      new Vendor() { Id = 9, Name = "Apple Vacations", Website = "https://www.applevacations.com", LoginWebsite = "https://www.vaxvacationaccess.com", Phone = "800-517-2000", Consortium = "VAX Vacation Access", Description = "U.S. tour operator known for beach vacations and charter flights." },
      new Vendor() { Id = 10, Name = "AmResorts", Website = "https://www.amrcollection.com", LoginWebsite = "https://www.amragents.com", Phone = "866-847-8184", Consortium = "", Description = "Collection of luxury resort brands in Mexico and the Caribbean." }
    };
  }
}
