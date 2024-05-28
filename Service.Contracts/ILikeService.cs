using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface ILikeService
{
    Task LikePostAsync(Guid userId, Guid postId, bool trackChanges);
    Task UnLikePostAsync(Guid userId, Guid postId, bool trackChanges);
    Task<IEnumerable<LikeDTO>> GetLikesByUserAsync(Guid userId, bool trackChanges);    
}
