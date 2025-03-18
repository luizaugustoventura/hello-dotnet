using System.Text.Json.Serialization;

namespace HelloDotnet.DTOs
{
  public class CreateVehicleDTO
  {
    public required string Model { get; set; }
    [JsonPropertyName("license_plate")]
    public required string LicensePlate { get; set; }
  }
}