namespace Commander.Dtos
{
  public class CommandDto
  {
    public int Id { get; set; }

    public string HowTo { get; set; } = null!;

    public string Platform { get; set; } = null!;

    public string Line { get; set; } = null!;
  }
}