using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

internal sealed class UserFollowedService : IUserFollowedService
{
    private readonly IRepositoryManager _repository;
    private readonly IEntityCheckService _entityCheck;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public UserFollowedService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IEntityCheckService entityCheck)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _entityCheck = entityCheck;
    }

    public async Task<IEnumerable<UserFollowedDTO>> GetUsersFollowedByIdAsync(Guid userId, bool trackChanges)
    {
        await _entityCheck.CheckIfUserExists(userId, trackChanges);

        var usersFollowed = await _repository.UserFollowed.GetUsersFollowedAsync(userId, trackChanges);

        var usersFollowedDto = _mapper.Map<IEnumerable<UserFollowedDTO>>(usersFollowed);

        return usersFollowedDto;
    }

    public async Task FollowUserAsync(Guid userId, Guid followerId, bool trackChanges)
    {
        await _entityCheck.CheckIfUserExists(userId, trackChanges);

        await _entityCheck.CheckIfUserExists(followerId, trackChanges);

        if (userId == followerId)
            throw new UserFollowingBadRequestException();

        var usersFollowed = await _repository.UserFollowed.GetUsersFollowedAsync(userId, trackChanges);

        if (usersFollowed.Any(f => f.UserId == userId && f.UsersFollowedId == followerId))
            throw new UserAlreadyFollowingBadRequestException();

        UserFollowedDTO userFollowedDTO = new()
        {
            UserId = userId,
            UsersFollowedId = followerId
        };

        var userFollowedEntity = _mapper.Map<UserFollowed>(userFollowedDTO);

        _repository.UserFollowed.FollowUserAsync(userFollowedEntity, trackChanges);          

        await _repository.SaveAsync();
    }

    public async Task UnFollowUserAsync(Guid userId, Guid followerId, bool trackChanges)
    {
        await _entityCheck.CheckIfUserExists(userId, trackChanges);

        await _entityCheck.CheckIfUserExists(followerId, trackChanges);

        var usersFollowed = await _repository.UserFollowed.GetUsersFollowedAsync(userId, trackChanges);

        var unfollowedUser = usersFollowed
            .Where(u => u.UsersFollowedId == followerId)
            .SingleOrDefault();        

        _repository.UserFollowed.UnFollowUserAsync(unfollowedUser);

        await _repository.SaveAsync();

    }
}
