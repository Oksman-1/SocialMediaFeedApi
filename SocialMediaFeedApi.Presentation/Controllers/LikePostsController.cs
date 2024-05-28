using Marvin.Cache.Headers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTranferObjects;

namespace SocialMediaFeedApi.Presentation.Controllers;

[Route("api/{userId}/like")]
[ApiController]
[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
[HttpCacheValidation(MustRevalidate = false)]
public class LikePostsController : ControllerBase
{
    private readonly IServiceManager _service;
    public LikePostsController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets a list of likes by a User
    /// </summary>
    /// <returns>A list of likes by a User</returns>
    [HttpGet]
    public async Task<IActionResult> GetLikesByUser(Guid userId)
    {
        var LikesByUser = await _service.LikeService.GetLikesByUserAsync(userId, trackChanges: false); ;

        return Ok(LikesByUser);
    }

    /// <summary>
    /// To Like a Post
    /// </summary>
    /// <param name="userId"></param>
    /// /// <param name="postId"></param>
    /// <returns>Ok Message</returns>
    /// <response code="200">Ok</response>
    [HttpPost("{postId:Guid}")]
    public async Task<IActionResult> LikePost(Guid userId, Guid postId)
    {
        await _service.LikeService.LikePostAsync(userId, postId, trackChanges: true);

        return Ok(new { Message = $"Post with Id {postId} liked successfully"});
    }


    /// <summary>
    /// To Unlike a Post
    /// </summary>
    /// <returns>No Content</returns>
    [HttpDelete("{postId:Guid}")]
    public async Task<IActionResult> UnLikePost(Guid userId, Guid postId)
    {
        await _service.LikeService.UnLikePostAsync(userId, postId, trackChanges: true);

        return Ok(new { Message = $"Post with Id {postId} Unliked successfully" });
    }


}
