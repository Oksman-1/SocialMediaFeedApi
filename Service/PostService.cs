using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTranferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service;

internal sealed class PostService : IPostService
{
    private readonly IRepositoryManager _repository;
    private readonly IEntityCheckService _entityCheck;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public PostService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IEntityCheckService entityCheck)
    {
        _repository = repository;
        _entityCheck = entityCheck;
        _logger = logger;
        _mapper = mapper;       
    }

    public async Task<IEnumerable<PostDTO>> GetPostsByUserAsync(Guid userId, PaginationParameters paginationParameters, bool trackChanges)
    {
        await _entityCheck.CheckIfUserExists(userId, trackChanges);

        var posts = await _repository.Post.GetPostsByUserAsync(userId, paginationParameters, trackChanges);

        var postsDto = _mapper.Map<IEnumerable<PostDTO>>(posts);

        return postsDto;
    }

    public async Task<PostDTO> GetPostForUserByIdAsync(Guid userId, Guid postId, bool trackChanges)
    {
        var user = await _entityCheck.CheckIfUserExists(userId, trackChanges);

        if (!user.Posts.Any(p => p.PostId == postId))
            throw new PostByUserNotFoundException(userId);

        var post = await _repository.Post.GetPostForUserByIdAsync(userId, postId, trackChanges);   

        var postDto = _mapper.Map<PostDTO>(post);

        return postDto;
    }

    public async Task<IEnumerable<PostDTO>> GetPostFeedByUserAndUsersFollowedAsync(Guid userId, PaginationParameters paginationParameters, bool trackChanges)
    {
        var allPostDTOs = new List<PostDTO>();

        var userPosts = await _repository.Post.GetPostsByUserAsync(userId, paginationParameters, trackChanges);

        var userPostDtos = _mapper.Map<IEnumerable<PostDTO>>(userPosts);
        allPostDTOs.AddRange(userPostDtos);

        var user = await _entityCheck.CheckIfUserExists(userId, trackChanges);

        var userAndUsersFollowed =  user.UsersFollowed
                                        .Select(user => user.UsersFollowedId)                                        
                                        .ToList();

        foreach(Guid _ in userAndUsersFollowed)
        {
            var posts = await _repository.Post.GetPostsByUserAsync(_, paginationParameters, trackChanges);
            var postDtos = _mapper.Map<IEnumerable<PostDTO>>(posts);
            allPostDTOs.AddRange(postDtos);
        }

        return allPostDTOs
            .OrderByDescending(p => p.Likes.Count)
            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
            .Take(paginationParameters.PageSize);
    }

    public async Task<PostDTO> CreatePostForUserAsync(Guid userId, PostForCreationDTO postForCreation, bool trackChanges)
    {
        await _entityCheck.CheckIfUserExists(userId, trackChanges);

        var post = _mapper.Map<Post>(postForCreation);

        _repository.Post.CreatePostForUser(userId, post);

        await _repository.SaveAsync();

        var createdPost = _mapper.Map<PostDTO>(post);

        return createdPost;
    }

    public async Task DeletePostForUserAsync(Guid userId, Guid postId, bool trackChanges)
    {
        var user = await _entityCheck.CheckIfUserExists(userId, trackChanges);

        var post = await _repository.Post.GetPostForUserByIdAsync(userId, postId, trackChanges);
        if (post is null)
            throw new PostCreationBadRequestException(postId);

        if (!user.Posts.Any(p => p.PostId == postId))
            throw new PostByUserNotFoundException(userId);

        _repository.Post.DeletePost(post);

        await _repository.SaveAsync();
    }

    public Task DeleteAllPostsForUserAsync(Guid userId, Guid postId, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}