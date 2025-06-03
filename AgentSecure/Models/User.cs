using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgentSecure.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Uid { get; set; }

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string StreetAddress { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string Zip { get; set; }

    // Navigation properties
    public List<Login> Logins { get; set; }
  }
}
