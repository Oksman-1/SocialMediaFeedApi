using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record UserFollowedDTO
{
    //public Guid FollowId { get; set; }
    public Guid UserId { get; set; }
    public Guid UsersFollowedId { get; set; }

    //Reference Navigational Properties
    //public User? User { get; set; }
    //public User? UsersFollowed { get; set; }
}
