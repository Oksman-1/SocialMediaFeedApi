using Entities.Models;
using Shared.DataTranferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface IPostService
{

    //Task<IEnumerable<PostDTO>> GetPostsByIdAsync(Guid postId, bool trackChanges);
    Task<IEnumerable<PostDTO>> GetPostsByUserAsync(Guid userId, PaginationParameters paginationParameters, bool trackChanges);
    Task<IEnumerable<PostDTO>> GetPostFeedByUserAndUsersFollowedAsync(Guid userId, PaginationParameters paginationParameters, bool trackChanges);
    Task<PostDTO> GetPostForUserByIdAsync(Guid userId, Guid postId, bool trackChanges);
    Task<PostDTO> CreatePostForUserAsync(Guid userId, PostForCreationDTO postForCreation, bool trackChanges);
    Task DeletePostForUserAsync(Guid userId, Guid postId, bool trackChanges);
    Task DeleteAllPostsForUserAsync(Guid userId, Guid postId, bool trackChanges);
}








