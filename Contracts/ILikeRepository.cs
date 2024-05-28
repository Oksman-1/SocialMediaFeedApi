using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface ILikeRepository
{
    void LikePostAsync(Like like, bool trackChanges);
    void UnLikePostAsync(Like like);
    Task<IEnumerable<Like>> GetLikesByUserAsync(Guid userId, bool trackChanges);   
    Task<IEnumerable<Like>> GetAllLikesAsync(bool trackChanges);   
}
