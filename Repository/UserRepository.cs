using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {

    }

    public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(c => c.Posts)            
            .Include(c => c.Likes)
            .Include(c => c.UsersFollowed)
            .OrderBy(c => c.Username)
            .ToListAsync();

    public async Task<User> GetUserByIdAsync(Guid userId, bool trackChanges) =>
            await FindByCondition(c => c.UserId.Equals(userId), trackChanges)
            .Include(c => c.Posts)
            .Include(c => c.Likes)
            .Include(c => c.UsersFollowed)
            .SingleOrDefaultAsync();

    public void CreateUser(User user) => Create(user);

    public void DeleteUser(User user) => Delete(user);


}
