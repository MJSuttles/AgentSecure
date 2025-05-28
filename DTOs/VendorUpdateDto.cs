namespace AgentSecure.DTOs
{
  public class VendorUpdateDto
  {
    public string Name { get; set; }
    public string Website { get; set; }
    public string LoginWebsite { get; set; }
    public string Phone { get; set; }
    public string? Consortium { get; set; }
    public string Description { get; set; }
    public List<string> Categories { get; set; }
  }
}
