using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface IPostRepository
{
    Task<Post> GetPostByIdAsync(Guid postId, bool trackChanges);
    Task<IEnumerable<Post>> GetPostsByUserAsync(Guid userId, PaginationParameters paginationParameters, bool trackChanges);
    Task<Post> GetPostForUserByIdAsync(Guid userId, Guid postId, bool trackChanges);
    void CreatePostForUser(Guid userId, Post post);
    void DeletePost(Post post);   
}
