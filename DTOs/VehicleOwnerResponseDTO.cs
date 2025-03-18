namespace HelloDotnet.DTOs
{
  public class VehicleOwnerResponseDTO
  {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
  }
}