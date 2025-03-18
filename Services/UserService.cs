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

  public async Task<UserResponseDTO[]> GetAllUsersAsync()
  {
    var users = await _userRepository.GetAllUsersAsync();
    var usersResponse = new UserResponseDTO[users.Length];
    for (int i = 0; i < users.Length; i++)
    {
      var user = users[i];
      var userResponse = new UserResponseDTO
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        Vehicles = [],
      };
      user.Vehicles?.ToList().ForEach(v => userResponse.Vehicles.Add(new UserVehicleResponseDTO
      {
        Id = v.Id,
        Model = v.Model,
        LicensePlate = v.LicensePlate,
      }));
      usersResponse[i] = userResponse;
    }

    return usersResponse;
  }

  public async Task<UserResponseDTO?> GetUserByIdAsync(Guid id)
  {
    var user = await _userRepository.GetUserByIdAsync(id) ?? throw new ArgumentException("User not found");
    var userResponse = new UserResponseDTO
    {
      Id = user.Id,
      Name = user.Name,
      Email = user.Email,
      Vehicles = [],
    };
    user.Vehicles?.ToList().ForEach(v => userResponse.Vehicles.Add(new UserVehicleResponseDTO
    {
      Id = v.Id,
      Model = v.Model,
      LicensePlate = v.LicensePlate,
    }));

    return userResponse;
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
      LicensePlate = vehicle.LicensePlate,
      Owner = owner
    };
    var createdVehicle = await _userRepository.AddNewVehicleAsync(newVehicle);
    var createdVehicleResponse = new VehicleResponseDTO
    {
      Id = createdVehicle.Id,
      Model = createdVehicle.Model,
      LicensePlate = createdVehicle.LicensePlate,
      Owner = new VehicleOwnerResponseDTO
      {
        Id = owner.Id,
        Name = owner.Name,
        Email = owner.Email
      }
    };
    return createdVehicleResponse;
  }
}