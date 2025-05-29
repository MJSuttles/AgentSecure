namespace AgentSecure.DTOs
{
  public class LoginUpdateDto
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RegApproved { get; set; }
    public bool TrainingComplete { get; set; }
  }
}
