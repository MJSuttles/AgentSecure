namespace AgentSecure.DTOs
{
  public class ChangePasswordDto
  {
    public int LoginId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
  }
}
