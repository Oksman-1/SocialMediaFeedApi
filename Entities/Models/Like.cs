namespace Entities.Models;

public class Like
{
    //PK
    public Guid LikeId { get; set; }
    //public LikeState? LikeState { get; set; }

    //FKs
    //[ForeignKey(nameof(PostId))]
    public Guid PostId { get; set; }

    //[ForeignKey(nameof(UserId))]
    public Guid UserId { get; set; }

    //Reference Navigational Properties
    public Post? Post { get; set; }
    public User? User { get; set; }
}

//public enum LikeState
//{
//   Liked = 0,
//   Unliked = 1
//}
