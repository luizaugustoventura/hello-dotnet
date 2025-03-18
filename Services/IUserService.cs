using HelloDotnet.DTOs;
using HelloDotnet.Models;

public interface IUserService
{
  Task<User> CreateUserAsync(User user);
  Task<UserResponseDTO[]> GetAllUsersAsync();
  Task<UserResponseDTO?> GetUserByIdAsync(Guid id);
  Task DeleteUserByIdAsync(Guid id);
  Task<VehicleResponseDTO> AddNewVehicleAsync(Guid ownerId, CreateVehicleDTO vehicle);
}