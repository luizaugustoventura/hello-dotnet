namespace HelloDotnet.DTOs
{
  public class UserResponseDTO
  {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public List<UserVehicleResponseDTO>? Vehicles { get; set; }
  }
}