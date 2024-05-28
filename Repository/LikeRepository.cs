using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
    public LikeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {

    }

    public async Task<IEnumerable<Like>> GetAllLikesAsync(bool trackChanges) =>
            await FindAll(trackChanges)           
            .OrderBy(c => c.PostId)
            .ToListAsync();


    public async Task<IEnumerable<Like>> GetLikesByUserAsync(Guid userId, bool trackChanges) =>
        await FindByCondition(l => l.UserId == userId, trackChanges)
              .ToListAsync();
    

    public void LikePostAsync(Like like, bool trackChanges) => Create(like);


    public void UnLikePostAsync(Like like) => Delete(like);

}