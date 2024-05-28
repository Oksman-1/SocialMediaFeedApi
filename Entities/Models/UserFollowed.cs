namespace Entities.Models;

public class UserFollowed
{
    //PK
    public Guid FollowId { get; set; }
    
    //FKs    
    public Guid UserId { get; set; }      
    public Guid UsersFollowedId { get; set; }

    //Reference Navigational Property
    public User? User { get; set; }
   // public User? UsersFollowed { get; set; }
}
