using Entities.Models;
using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface IUserFollowedService
{
    Task FollowUserAsync(Guid userId, Guid followerId, bool trackChanges);
    Task UnFollowUserAsync(Guid userId, Guid followerId, bool trackChanges);
    Task<IEnumerable<UserFollowedDTO>> GetUsersFollowedByIdAsync(Guid userId, bool trackChanges);   
}
