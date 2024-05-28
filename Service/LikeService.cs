using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Service.Contracts;
using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

internal sealed class LikeService : ILikeService
{
    private readonly IRepositoryManager _repository;
    private readonly IEntityCheckService _entityCheck;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public LikeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IEntityCheckService entityCheck)
    {
        _repository = repository;
        _entityCheck = entityCheck;
        _logger = logger;
        _mapper = mapper;
       
    }

    public async Task<IEnumerable<LikeDTO>> GetLikesByUserAsync(Guid userId, bool trackChanges)
    {
        await _entityCheck.CheckIfUserExists(userId, trackChanges);

        var likesByUser = await _repository.Like.GetLikesByUserAsync(userId, trackChanges);

        var likesByUserDto = _mapper.Map<IEnumerable<LikeDTO>>(likesByUser);

        return likesByUserDto;
    }

    public async Task LikePostAsync(Guid userId, Guid postId, bool trackChanges)
    {
        //Check if user and post exist in db
        await _entityCheck.CheckIfUserAndPostExists(userId, postId, trackChanges);

        //Get all likes
        var likes = await _repository.Like.GetAllLikesAsync(trackChanges);

        //Check that like dosen't previously exist in db
        if (likes.Any(l => l.PostId == postId && l.UserId == userId))
            throw new PostLikedBadRequest(userId);

        //Set IsLiked property of liked post to true         
        var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges);
        post.IsLiked = true;

        //Set Properties
        LikeForCreationDTO _ = new()
        {
           PostId = postId,
           UserId = userId
        };

        var likeEntity = _mapper.Map<Like>(_);

        _repository.Like.LikePostAsync(likeEntity, trackChanges);

        await _repository.SaveAsync();
    }

    public async Task UnLikePostAsync(Guid userId, Guid postId, bool trackChanges)
    {
        //Check if user and post exist in db
        await _entityCheck.CheckIfUserAndPostExists(userId, postId, trackChanges);

        //Get all likes
        var likes = await _repository.Like.GetAllLikesAsync(trackChanges);

        //Check that like dosen't previously exist in db
        if (!likes.Any(l => l.PostId == postId && l.UserId == userId))
            throw new LikeNotFoundException();

        var likesByUser = await _repository.Like.GetLikesByUserAsync(userId, trackChanges);

        var matchedLiked = likesByUser
            .Where(u => u.PostId == postId)
            .SingleOrDefault();

        _repository.Like.UnLikePostAsync(matchedLiked);

        //Set IsLiked property of liked post to false       
        var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges);
        if (post.Likes.Count == 1)
        {
            post.IsLiked = false;
        }

        await _repository.SaveAsync();
    }

  
}
