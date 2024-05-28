using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
    Task<User> GetUserByIdAsync(Guid userId, bool trackChanges);
    void CreateUser(User user);
    void DeleteUser(User user);
}
