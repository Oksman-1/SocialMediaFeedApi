using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class UserFollowedRepository : RepositoryBase<UserFollowed>, IUserFollowedRepository
{
    public UserFollowedRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {

    }

    public async Task<IEnumerable<UserFollowed>> GetUsersFollowedAsync(Guid userId, bool trackChanges) =>
            await FindByCondition(c => c.UserId.Equals(userId), trackChanges)
                 .ToListAsync();

    public void FollowUserAsync(UserFollowed userFollowed, bool trackChanges)
    {     
        Create(userFollowed);
    }

    public void UnFollowUserAsync(UserFollowed userFollowed) => Delete(userFollowed);

    public bool IsFollowing(Guid userId, Guid followerId, bool trackChanges)
    {
        throw new NotImplementedException();
    }


}

