using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record LikeDTO
{
   
    public Guid LikeId { get; set; }    
    public Guid PostId { get; set; }    
    public Guid UserId { get; set; }

    //Reference Navigational Properties
    //public Post? Post { get; set; }
    //public User? User { get; set; }
}
