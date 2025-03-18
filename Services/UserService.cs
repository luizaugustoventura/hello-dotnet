using HelloDotnet.DTOs;
using HelloDotnet.Models;

public class UserService : IUserService
{
  private readonly IUserRespository _userRepository;

  public UserService(IUserRespository userRespository)
  {
    _userRepository = userRespository;
  }

  public async Task<User> CreateUserAsync(User user)
  {
    if (string.IsNullOrEmpty(user.Name))
    {
      throw new ArgumentException("User name cannot be empty");
    }

    if (string.IsNullOrEmpty(user.Email))
    {
      throw new ArgumentException("Email cannot be empty");
    }

    return await _userRepository.AddUserAsync(user);
  }

  public async Task<User[]> GetAllUsersAsync()
  {
    return await _userRepository.GetAllUsersAsync();
  }

  public async Task<User?> GetUserByIdAsync(Guid id)
  {
    return await _userRepository.GetUserByIdAsync(id);
  }

  public async Task DeleteUserByIdAsync(Guid id)
  {
    await _userRepository.DeleteUserByIdAsync(id);
  }

  public async Task<VehicleResponseDTO> AddNewVehicleAsync(Guid ownerId, CreateVehicleDTO vehicle)
  {
    var owner = await _userRepository.GetUserByIdAsync(ownerId) ?? throw new ArgumentException("Owner not found");
    var newVehicle = new Vehicle
    {
      Model = vehicle.Model,
      FlexPlate = vehicle.FlexPlate,
      Owner = owner
    };
    var createdVehicle = await _userRepository.AddNewVehicleAsync(newVehicle);
    var vehicleResponse = new VehicleResponseDTO{
      Id = createdVehicle.Id,
      Model = createdVehicle.Model,
      FlexPlate = createdVehicle.FlexPlate,
      Owner = new  VehicleOwnerResponseDTO {
        Id = owner.Id,
        Name = owner.Name,
        Email = owner.Email
      }
    };
    return vehicleResponse;
  }
}