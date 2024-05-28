using Entities.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTranferObjects;

namespace SocialMediaFeedApi.Presentation.Controllers;

[Route("api/{userId}/follow")]
[ApiController]
[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
[HttpCacheValidation(MustRevalidate = false)]
public class UsersFollowedController : ControllerBase
{
    private readonly IServiceManager _service;
    public UsersFollowedController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets a list users followed by a User
    /// </summary>
    /// <returns>A list of users followed by a User</returns>
    [HttpGet]
    public async Task<IActionResult> GetUsersFollowedById(Guid userId)
    {
        var usersFollowed = await _service.UserFollowedService.GetUsersFollowedByIdAsync(userId, trackChanges: false); ;

        return Ok(usersFollowed);
    }

    /// <summary>
    /// To follow a user
    /// </summary>
    /// <param name="userId"></param>
    /// /// <param name="followerId"></param>
    /// <returns>Ok Message</returns>
    /// <response code="200">Ok</response>
    [HttpPost("{followerId:Guid}")]
    public async Task<IActionResult> FollowUser(Guid userId, Guid followerId)
    {
       await _service.UserFollowedService.FollowUserAsync(userId, followerId, trackChanges: true);

        return Ok(new { Message = $"User with Id {followerId} followed successfully" });        
    }

    /// <summary>
    /// To Unfollow a user
    /// </summary>
    /// <returns>No Content</returns>
    [HttpDelete("{followerId:Guid}")]
    public async Task<IActionResult> UnFollowUser(Guid userId, Guid followerId)
    {
        await _service.UserFollowedService.UnFollowUserAsync(userId, followerId, trackChanges: false);

        return Ok(new { Message = $"User with Id {followerId} Unfollowed successfully" });
    }

}
