using CompanyEmployees.Presentation.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTranferObjects;

namespace SocialMediaFeedApi.Presentation.Controllers;

[Route("api/users")]
[ApiController]
[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
[HttpCacheValidation(MustRevalidate = false)]
public class UsersController : ControllerBase
{
	private readonly IServiceManager _service;
	public UsersController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the list of all Users
    /// </summary>
    /// <returns>The list of all users</returns>
    [HttpGet]
    public async Task<IActionResult> GetUsers()
	{		
		var users = await _service.UserService.GetAllUsersAsync(trackChanges: false);

		return Ok(users);		
	}

    /// <summary>
    /// Gets a User by Id
    /// </summary>
    /// <returns>A user by Id</returns>
	[HttpGet("{userId:Guid}", Name = "UserById")]
    public async Task<IActionResult> GetSchool(Guid userId)
	{
		var user = await _service.UserService.GetUserByIdAsync(userId, trackChanges: false);

		return Ok(user);
	}

    /// <summary>
    /// Creates a new User
    /// </summary>
    /// <param name="user"></param>
    /// <returns>A newly created user</returns>
    /// <response code="201">Returns the newly created user</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateUser([FromBody] UserForCreationDTO user)
	{

		var createdUser = await _service.UserService.CreateUserAsync(user);

		return CreatedAtRoute("UserById", new { createdUser.UserId }, createdUser);
	}


    /// <summary>
    /// Deletes a User
    /// </summary>
    /// <returns>No Content</returns>
    [HttpDelete("{userId:Guid}")]
	public async Task<IActionResult> DeleteUser(Guid userId)
	{
		await _service.UserService.DeleteUserAsync(userId, trackChanges: false);

		return Ok(new { Message = $"User with Id {userId} deleted successfully" });
	}
	
}
