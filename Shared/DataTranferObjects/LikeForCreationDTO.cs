using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record LikeForCreationDTO
{
    //public Guid LikeId { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
}
