using Entities.Models;
using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface IEntityCheckService
{
    Task<User> CheckIfUserExists(Guid userId, bool trackChanges);
    Task CheckIfUserAndPostExists(Guid userId, Guid postId, bool trackChanges);

    //Task<(User checkedUser, Post checkedPost)> CheckIfUserAndPostExists(Guid userId, Guid postId, bool trackChanges);
}
