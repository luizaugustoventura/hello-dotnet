using System.Text.Json.Serialization;

namespace HelloDotnet.DTOs
{
  public class UserVehicleResponseDTO
  {
    public required Guid Id { get; set; }
    public required string Model { get; set; }
    [JsonPropertyName("license_plate")]
    public required string LicensePlate { get; set; }

  }
}