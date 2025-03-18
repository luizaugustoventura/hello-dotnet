using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDotnet.Models
{
  [Table("users")]
  public class User
  {
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [Column("name")]
    public required string Name { get; set; }

    [Required]
    [Column("email")]
    public required string Email { get; set; }

    public ICollection<Vehicle>? Vehicles { get; set; }
  }
}