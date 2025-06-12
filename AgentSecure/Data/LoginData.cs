using AgentSecure.Models;
using AgentSecure.Helpers;

namespace AgentSecure.Data
{
  public static class LoginData
  {
    public static List<Login> GetEncryptedLogins()
    {
      return new List<Login>
      {
        new Login
        {
          Id = 1,
          UserId = 1,
          VendorId = 1,
          Username = "alice.viking",
          Email = "alice.j@viking.com",
          Password = EncryptionHelper.Encrypt("VikingPass1!"),
          RegApproved = true,
          TrainingComplete = true
        },
        new Login
        {
          Id = 2,
          UserId = 1,
          VendorId = 3,
          Username = "alice.sandals",
          Email = "alice.s@sandals.com",
          Password = EncryptionHelper.Encrypt("SandalsPass2@"),
          RegApproved = true,
          TrainingComplete = false
        },
        new Login
        {
          Id = 3,
          UserId = 1,
          VendorId = 5,
          Username = "alice.rccl",
          Email = "alice.r@royal.com",
          Password = EncryptionHelper.Encrypt("RoyalPass3#"),
          RegApproved = false,
          TrainingComplete = false
        },
        new Login
        {
          Id = 4,
          UserId = 1,
          VendorId = 9,
          Username = "alice.apple",
          Email = "alice.a@applevacs.com",
          Password = EncryptionHelper.Encrypt("ApplePass4$"),
          RegApproved = true,
          TrainingComplete = true
        },
        new Login
        {
          Id = 5,
          UserId = 1,
          VendorId = 4,
          Username = "alice.disney",
          Email = "alice.d@disney.com",
          Password = EncryptionHelper.Encrypt("DisneyPass5%"),
          RegApproved = true,
          TrainingComplete = true
        },
        new Login
        {
          Id = 6,
          UserId = 2,
          VendorId = 2,
          Username = "bob.delta",
          Email = "bob.d@delta.com",
          Password = EncryptionHelper.Encrypt("DeltaPass6^"),
          RegApproved = true,
          TrainingComplete = false
        },
        new Login
        {
          Id = 7,
          UserId = 2,
          VendorId = 6,
          Username = "bob.globus",
          Email = "bob.g@globus.com",
          Password = EncryptionHelper.Encrypt("GlobusPass7&"),
          RegApproved = false,
          TrainingComplete = false
        },
        new Login
        {
          Id = 8,
          UserId = 2,
          VendorId = 7,
          Username = "bob.ti",
          Email = "bob.t@ti.com",
          Password = EncryptionHelper.Encrypt("TiPass8*"),
          RegApproved = true,
          TrainingComplete = true
        },
        new Login
        {
          Id = 9,
          UserId = 2,
          VendorId = 8,
          Username = "bob.expedia",
          Email = "bob.e@expedia.com",
          Password = EncryptionHelper.Encrypt("ExpediaPass9("),
          RegApproved = true,
          TrainingComplete = false
        },
        new Login
        {
          Id = 10,
          UserId = 2,
          VendorId = 10,
          Username = "bob.amresorts",
          Email = "bob.a@amr.com",
          Password = EncryptionHelper.Encrypt("AmrPass10)"),
          RegApproved = true,
          TrainingComplete = true
        }
      };
    }
  }
}
