using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgentSecure.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string CatName { get; set; }

    // Navigation properties
    public List<VendorCategory> VendorCategories { get; set; }
  }
}
