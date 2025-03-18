using System.Text.Json.Serialization;

namespace HelloDotnet.DTOs
{
  public class VehicleResponseDTO
  {
    public required Guid Id { get; set; }
    public required string Model { get; set; }
    [JsonPropertyName("flex_plate")]
    public required string FlexPlate { get; set; }
    public required VehicleOwnerResponseDTO Owner { get; set; }
  }
}