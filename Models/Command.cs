using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
  [Table("commands")]
  public class Command
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string HowTo { get; set; } = null!;

    [Required]
    public string Platform { get; set; } = null!;

    [Required]
    public string Line { get; set; } = null!;
  }
}