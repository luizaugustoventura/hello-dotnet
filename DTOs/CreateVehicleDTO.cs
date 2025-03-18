using System.Text.Json.Serialization;

namespace HelloDotnet.DTOs
{
  public class CreateVehicleDTO
  {
    public required string Model { get; set; }
    [JsonPropertyName("flex_plate")]
    public required string FlexPlate { get; set; }
  }
}