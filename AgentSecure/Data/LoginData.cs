using AgentSecure.Models;

namespace AgentSecure.Data
{
  public class LoginData
  {
    public static List<Login> Logins = new()
    {
      // Seed data

      new Login() { Id = 1, UserId = 1, VendorId = 1, Username = "alice.viking", Email = "alice.j@viking.com", Password = "Pass123!", RegApproved = true, TrainingComplete = true },
      new Login() { Id = 2, UserId = 1, VendorId = 3, Username = "alice.sandals", Email = "alice.s@sandals.com", Password = "Tropic123!", RegApproved = true, TrainingComplete = false },
      new Login() { Id = 3, UserId = 1, VendorId = 5, Username = "alice.rccl", Email = "alice.r@royal.com", Password = "CruiseIt!", RegApproved = false, TrainingComplete = false },
      new Login() { Id = 4, UserId = 1, VendorId = 9, Username = "alice.apple", Email = "alice.a@applevacs.com", Password = "BeachTime!", RegApproved = true, TrainingComplete = true },
      new Login() { Id = 5, UserId = 1, VendorId = 4, Username = "alice.disney", Email = "alice.d@disney.com", Password = "Magic123!", RegApproved = true, TrainingComplete = true },

      new Login() { Id = 6, UserId = 2, VendorId = 2, Username = "bob.delta", Email = "bob.d@delta.com", Password = "SkyHigh1!", RegApproved = true, TrainingComplete = false },
      new Login() { Id = 7, UserId = 2, VendorId = 6, Username = "bob.globus", Email = "bob.g@globus.com", Password = "Tours2024!", RegApproved = false, TrainingComplete = false },
      new Login() { Id = 8, UserId = 2, VendorId = 7, Username = "bob.ti", Email = "bob.t@ti.com", Password = "ResortLife!", RegApproved = true, TrainingComplete = true },
      new Login() { Id = 9, UserId = 2, VendorId = 8, Username = "bob.expedia", Email = "bob.e@expedia.com", Password = "EasyBook!", RegApproved = true, TrainingComplete = false },
      new Login() { Id = 10, UserId = 2, VendorId = 10, Username = "bob.amresorts", Email = "bob.a@amr.com", Password = "AMRsecure!", RegApproved = true, TrainingComplete = true }
    };
  }
}
