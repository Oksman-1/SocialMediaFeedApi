using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public class EntityCheck : IEntityCheckService
{
    private readonly IRepositoryManager _repository;
   
    public EntityCheck(IRepositoryManager repository)
    {
        _repository = repository;
    }

  
    //Check and return user
    public async Task<User> CheckIfUserExists(Guid userId, bool trackChanges)
    {
        var user = await _repository.User.GetUserByIdAsync(userId, trackChanges);
        if (user is null)
            throw new UserNotFoundException(userId);

        return user;
    }

    //Check for user only
    public async Task CheckIfUserExists(Guid userId, bool trackChanges, object? _ = null)
    {
        var user = await _repository.User.GetUserByIdAsync(userId, trackChanges);
        if (user is null)
            throw new UserNotFoundException(userId);        
    }

    //Check for user and post only
    public async Task CheckIfUserAndPostExists(Guid userId, Guid postId, bool trackChanges)
    {
        var user = await _repository.User.GetUserByIdAsync(userId, trackChanges);
        if (user is null)
            throw new UserNotFoundException(userId);

        var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges);
        if (post is null)
            throw new PostNotFoundException(postId);
    }

    //public async Task<(User checkedUser, Post checkedPost)> CheckIfUserAndPostExists(Guid userId, Guid postId, bool trackChanges)
    //{
    //    var user = await _repository.User.GetUserByIdAsync(userId, trackChanges);
    //    if (user is null)
    //        throw new UserNotFoundException(userId);

    //    var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges);
    //    if (post is null)
    //        throw new PostNotFoundException(postId);

    //    return (checkedUser: user, checkedPost: post);
    //}
}
