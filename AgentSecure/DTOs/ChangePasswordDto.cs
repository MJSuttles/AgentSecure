namespace AgentSecure.DTOs
{
  public class ChangePasswordDto
  {
    public int LoginId { get; set; }
    public string NewPassword { get; set; } = string.Empty;
    public string ConfirmNewPassword { get; set; } = string.Empty;
  }
}
