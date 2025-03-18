using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloDotnet.Models
{
  [Table("vehicles")]
  public class Vehicle
  {
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [Column("model")]
    public required string Model { get; set; }

    [Required]
    [Column("flex_plate")]
    public required string FlexPlate { get; set; }

    [Required]
    [ForeignKey("owner_id")]
    public required User Owner { get; set; }
  }
}