using System.Text.Json.Serialization;

namespace HelloDotnet.DTOs
{
  public class VehicleResponseDTO
  {
    public required Guid Id { get; set; }
    public required string Model { get; set; }
    [JsonPropertyName("license_plate")]
    public required string LicensePlate { get; set; }
    public required VehicleOwnerResponseDTO Owner { get; set; }
  }
}