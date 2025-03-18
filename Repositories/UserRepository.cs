using HelloDotnet.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRespository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<User> AddUserAsync(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<User[]> GetAllUsersAsync()
  {
    return await _context.Users.Include(u => u.Vehicles).ToArrayAsync();
  }

  public async Task<User?> GetUserByIdAsync(Guid id)
  {
    return await _context.Users.Include(u => u.Vehicles).FirstOrDefaultAsync(u => u.Id == id);
  }

  public async Task DeleteUserByIdAsync(Guid id)
  {
    var user = await _context.Users.FindAsync(id) ?? throw new ArgumentException("User not found");
    _context.Users.Remove(user);
    await _context.SaveChangesAsync();
  }

  public async Task<Vehicle> AddNewVehicleAsync(Vehicle vehicle)
  {
    _context.Vehicles.Add(vehicle);
    await _context.SaveChangesAsync();
    return vehicle;
  }
}