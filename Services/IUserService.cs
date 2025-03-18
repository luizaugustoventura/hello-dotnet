using HelloDotnet.DTOs;
using HelloDotnet.Models;

public interface IUserService
{
  Task<User> CreateUserAsync(User user);
  Task<User[]> GetAllUsersAsync();
  Task<User?> GetUserByIdAsync(Guid id);
  Task DeleteUserByIdAsync(Guid id);
  Task<VehicleResponseDTO> AddNewVehicleAsync(Guid ownerId, CreateVehicleDTO vehicle);
}