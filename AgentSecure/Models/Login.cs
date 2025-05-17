using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgentSecure.Models
{
  public class Login
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int VendorId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RegApproved { get; set; }
    public bool TrainingComplete { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Vendor Vendor { get; set; }
  }
}
