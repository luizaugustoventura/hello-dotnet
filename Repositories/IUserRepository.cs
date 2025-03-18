using HelloDotnet.Models;

public interface IUserRespository
{
  Task<User> AddUserAsync(User user);
  Task<User[]> GetAllUsersAsync();
  Task<User?> GetUserByIdAsync(Guid id);
  Task DeleteUserByIdAsync(Guid id);
  Task<Vehicle> AddNewVehicleAsync(Vehicle vehicle);
}