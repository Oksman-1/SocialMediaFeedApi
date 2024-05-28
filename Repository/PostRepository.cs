using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace Repository;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {

    }

    public async Task<Post> GetPostByIdAsync(Guid postId, bool trackChanges) => 
        await FindByCondition(s => s.PostId == postId, trackChanges)        
        .Include(p => p.Likes)
        .OrderByDescending(p => p.Likes.Count)
        .ThenByDescending(p => p.CreatedAt)
        //.Take(2)
        .SingleOrDefaultAsync();

    

    public async Task<IEnumerable<Post>> GetPostsByUserAsync(Guid userId, PaginationParameters paginationParameters, bool trackChanges) => 
        await FindByCondition(s => s.UserId == userId, trackChanges)
        .Include(p => p.Likes)      
        .OrderByDescending(p => p.Likes.Count)
        .ThenByDescending(p => p.CreatedAt)
        .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
        .Take(paginationParameters.PageSize)
        //.Take(2)
        .ToListAsync();

   
    public async Task<Post> GetPostForUserByIdAsync(Guid userId, Guid postId, bool trackChanges) => 
        await FindByCondition(s => s.UserId == userId && s.PostId == postId, trackChanges)
        .Include(p => p.Likes)
        .OrderByDescending(p => p.Likes.Count)
        .ThenByDescending(p => p.CreatedAt)
        //.Take(2)
        .SingleOrDefaultAsync();


    public void CreatePostForUser(Guid userId, Post post)
    {
        post.UserId = userId;
        post.IsLiked = false;    
		Create(post);
    }

    public void DeletePost(Post post) => Delete(post);
}
