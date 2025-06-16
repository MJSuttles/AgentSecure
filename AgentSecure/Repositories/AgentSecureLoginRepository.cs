using Microsoft.EntityFrameworkCore;
using AgentSecure.Data;
using AgentSecure.Interfaces;
using AgentSecure.Models;
using AgentSecure.DTOs;
using AgentSecure.Helpers;

namespace AgentSecure.Repositories
{
  public class AgentSecureLoginRepository : IAgentSecureLoginRepository
  {
    private readonly AgentSecureDbContext _context;

    public AgentSecureLoginRepository(AgentSecureDbContext context)
    {
      _context = context;
    }

    // Get all logins for the homepage
    public async Task<List<LoginDto>> GetAllLoginsAsync()
    {
      return await _context.Logins
        .Include(l => l.Vendor)
        .Select(l => new LoginDto
        {
          Id = l.Id,
          VendorName = l.Vendor.Name,
          Username = l.Username,
          Email = l.Email,
          Password = "[HIDDEN]", // Do not show password
          RegApproved = l.RegApproved,
          TrainingComplete = l.TrainingComplete
        })
        .ToListAsync();
    }

    // Get Logins by UserId

    public async Task<List<LoginDto>> GetLoginsByUserIdAsync(int userId)
    {
      return await _context.Logins
        .Include(l => l.Vendor)
        .Where(l => l.UserId == userId)
        .Select(l => new LoginDto
        {
          Id = l.Id,
          VendorName = l.Vendor.Name,
          Username = l.Username,
          Email = l.Email,
          Password = EncryptionHelper.Decrypt(l.Password),
          RegApproved = l.RegApproved,
          TrainingComplete = l.TrainingComplete
        })
        .ToListAsync();
    }

    // Get Login by Id

    public async Task<LoginDto?> GetLoginByIdAsync(int id)
    {
      return await _context.Logins
        .Include(l => l.Vendor)
        .Where(l => l.Id == id)
        .Select(l => new LoginDto
        {
          Id = l.Id,
          VendorName = l.Vendor.Name,
          Username = l.Username,
          Email = l.Email,
          Password = EncryptionHelper.Decrypt(l.Password),
          RegApproved = l.RegApproved,
          TrainingComplete = l.TrainingComplete
        })
        .FirstOrDefaultAsync();
    }

    public async Task<Login?> GetLoginByIdRawAsync(int id)
    {
      return await _context.Logins.FindAsync(id);
    }

    public async Task<Login> CreateLoginAsync(Login login)
    {
      // Only encrypt if not already encrypted (very basic check)
      if (!IsProbablyEncrypted(login.Password))
      {
        login.Password = EncryptionHelper.Encrypt(login.Password);
      }
      _context.Logins.Add(login);
      await _context.SaveChangesAsync();
      return login;
    }

    // Helper function
    private bool IsProbablyEncrypted(string password)
    {
      // Example: check for base64 string of expected length
      return password.Length % 4 == 0 && password.EndsWith("==");
    }

    // Update Login

    public async Task<LoginUpdateDto> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto)
    {
      var existingLogin = await _context.Logins.FindAsync(id);
      if (existingLogin == null) return null;

      existingLogin.Username = loginUpdateDto.Username;
      existingLogin.Email = loginUpdateDto.Email;

      // Only update password if a new one is provided and not empty or whitespace
      if (!string.IsNullOrWhiteSpace(loginUpdateDto.Password))
      {
        existingLogin.Password = EncryptionHelper.Encrypt(loginUpdateDto.Password);
      }

      existingLogin.RegApproved = loginUpdateDto.RegApproved;
      existingLogin.TrainingComplete = loginUpdateDto.TrainingComplete;

      await _context.SaveChangesAsync();

      return new LoginUpdateDto
      {
        Id = existingLogin.Id,
        Username = existingLogin.Username,
        Email = existingLogin.Email,
        Password = "[HIDDEN]",
        RegApproved = existingLogin.RegApproved,
        TrainingComplete = existingLogin.TrainingComplete
      };
    }
    // Delete Login

    public async Task<Login?> DeleteLoginAsync(int id)
    {
      var login = await _context.Logins.FindAsync(id);
      if (login != null)
      {
        _context.Logins.Remove(login);
        await _context.SaveChangesAsync();
        return login;
      }
      return null;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
    {
      var login = await _context.Logins.FindAsync(dto.LoginId);
      if (login == null) return false;

      if (dto.NewPassword != dto.ConfirmNewPassword)
      {
        return false;
      }

      login.Password = EncryptionHelper.Encrypt(dto.NewPassword);
      await _context.SaveChangesAsync();

      return true;
    }

    // Reveal Hidden Password

    public async Task<string?> RevealPasswordByLoginIdAsync(int loginId)
    {
      var login = await _context.Logins.FindAsync(loginId);
      if (login == null) return null;

      try
      {
        return EncryptionHelper.Decrypt(login.Password); // ✅ must decrypt
      }
      catch
      {
        return null; // fallback in case decryption fails
      }
    }
  }
}
