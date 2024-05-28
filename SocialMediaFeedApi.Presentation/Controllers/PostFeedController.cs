using CompanyEmployees.Presentation.ActionFilters;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTranferObjects;
using Shared.RequestFeatures;

namespace SocialMediaFeedApi.Presentation.Controllers;

[Route("api/{userId}/post")]
[ApiController]
[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
[HttpCacheValidation(MustRevalidate = false)]
public class PostFeedController : ControllerBase
{
    private readonly IServiceManager _service;
    public PostFeedController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets a list Posts by a User by userId
    /// </summary>
    /// <returns>A list of posts by a User</returns>
    [HttpGet]
    public async Task<IActionResult> GetPostsByUser(Guid userId, [FromQuery] PaginationParameters paginationParameters)
    {
        var posts = await _service.PostService.GetPostsByUserAsync(userId, paginationParameters, trackChanges: false);

        return Ok(posts);
    }

    /// <summary>
    /// Gets a list of Posts by User and users followed
    /// </summary>
    /// <returns>A list of Posts by User and users followed</returns>
    [HttpGet]
    [Route("get_postfeed_from_user_and_users_followed")]
    public async Task<IActionResult> GetPostFeedByUserAndUsersFollowedAsync(Guid userId, [FromQuery] PaginationParameters paginationParameters)
    {
        var posts = await _service.PostService.GetPostFeedByUserAndUsersFollowedAsync(userId, paginationParameters, trackChanges: false);

        return Ok(posts);
    }

    /// <summary>
    /// Gets a Post by a User by userId and postId
    /// </summary>
    /// <returns>A post by a User</returns>
    [HttpGet("{postId:Guid}", Name = "PostById")]
    public async Task<IActionResult> GetPostById(Guid userId, Guid postId)
    {
        var post = await _service.PostService.GetPostForUserByIdAsync(userId, postId, trackChanges: false);

        return Ok(post);
    }

    /// <summary>
    /// Creates a new post by a User
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="postForCreationDTO"></param>
    /// <returns>A newly created user post</returns>
    /// <response code="201">Returns the newly created user post</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePostForUser(Guid userId, [FromBody] PostForCreationDTO postForCreationDTO)
    {
        var createdPost = await _service.PostService.CreatePostForUserAsync(userId, postForCreationDTO, trackChanges: true);

        return CreatedAtRoute("PostById", new { userId, createdPost.PostId }, createdPost);
    }

    /// <summary>
    /// Deletes a User post
    /// </summary>
    /// <returns>No Content</returns>
    [HttpDelete("{postId:Guid}")]
    public async Task<IActionResult> DeletePostForUser(Guid userId, Guid postId)
    {
        await _service.PostService.DeletePostForUserAsync(userId, postId, trackChanges: false);

        return Ok(new { Message = $"Post with Id {postId} deleted successfully" });
    }


}
