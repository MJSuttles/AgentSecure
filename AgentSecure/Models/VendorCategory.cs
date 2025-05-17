using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgentSecure.Models
{
  public class VendorCategory
  {
    public int Id { get; set; }
    public int VendorId { get; set; }
    public int CategoryId { get; set; }

    // Navigation properties
    public Vendor Vendor { get; set; }
    public Category Category { get; set; }
  }
}
