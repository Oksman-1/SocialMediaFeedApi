using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface IUserFollowedRepository
{
    void FollowUserAsync(UserFollowed userFollowed, bool trackChanges);
    void UnFollowUserAsync(UserFollowed userFollowed);
    Task<IEnumerable<UserFollowed>> GetUsersFollowedAsync(Guid userId, bool trackChanges);
    bool IsFollowing(Guid userId, Guid followerId, bool trackChanges);
}
