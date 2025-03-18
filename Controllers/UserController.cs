using HelloDotnet.DTOs;
using HelloDotnet.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpPost]
  public async Task<IActionResult> CreateUser([FromBody] User user)
  {
    try
    {
      var createdUser = await _userService.CreateUserAsync(user);
      return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet]
  public async Task<IActionResult> GetAllUsersAsync()
  {
    var users = await _userService.GetAllUsersAsync();
    return Ok(users);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUserById(Guid id)
  {
    var user = await _userService.GetUserByIdAsync(id);
    if (user == null)
    {
      return NotFound(new { error = "User not found" });
    }
    return Ok(user);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUserByIdAsync(Guid id)
  {
    try
    {
      await _userService.DeleteUserByIdAsync(id);
      return NoContent();
    }
    catch (ArgumentException ex)
    {
      return NotFound(new { error = ex.Message });
    }
  }

  [HttpPost("{ownerId}/vehicles")]
  public async Task<IActionResult> AddNewVehicleAsync(Guid ownerId, CreateVehicleDTO vehicle)
  {
    try
    {
      var newVehicle = await _userService.AddNewVehicleAsync(ownerId, vehicle);
      return CreatedAtAction(nameof(GetUserById), new { id = newVehicle.Id }, newVehicle);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(ex.Message);
    }
  }
}