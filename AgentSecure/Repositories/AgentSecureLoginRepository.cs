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

    public async Task<Login> CreateLoginAsync(Login login)
    {
      // Encrypt the password before storing it
      login.Password = EncryptionHelper.Encrypt(login.Password);
      _context.Logins.Add(login);
      await _context.SaveChangesAsync();
      return login;
    }

    public async Task<LoginUpdateDto> UpdateLoginAsync(int id, LoginUpdateDto loginUpdateDto)
    {
      var existingLogin = await _context.Logins.FindAsync(id);
      if (existingLogin == null) return null;

      existingLogin.Username = loginUpdateDto.Username;
      existingLogin.Email = loginUpdateDto.Email;
      existingLogin.Password = EncryptionHelper.Encrypt(loginUpdateDto.Password);
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

      string decrypted = EncryptionHelper.Decrypt(login.Password);

      if (dto.CurrentPassword != decrypted)
      {
        return false; // current password incorrect
      }

      login.Password = EncryptionHelper.Encrypt(dto.NewPassword);

      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<string?> RevealPasswordByLoginIdAsync(int loginId)
    {
      var login = await _context.Logins.FindAsync(loginId);
      if (login == null) return null;

      try
      {
        return EncryptionHelper.Decrypt(login.Password);
      }
      catch
      {
        return null; // in case decryption fails
      }
    }
  }
}
