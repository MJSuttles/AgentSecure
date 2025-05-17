using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgentSecure.Models
{
  public class Vendor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public string LoginWebsite { get; set; }
    public string Phone { get; set; }
    public string? Consortium { get; set; }
    public string Description { get; set; }

    // Navigation properties
    public List<VendorCategory> VendorCategories { get; set; }
    public List<Login> Logins { get; set; }
  }
}
