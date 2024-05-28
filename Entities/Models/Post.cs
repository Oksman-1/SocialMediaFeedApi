namespace Entities.Models;

public class Post
{
    public Guid PostId { get; set; }

    //[Required(ErrorMessage = "Post Title is a required field.")]
    //[MaxLength(60, ErrorMessage = "Maximum length for the Post Title is 60 characters.")]
    //public string? PostTitle { get; set; }

    //[Required(ErrorMessage = "Post Body is a required field.")]
    //[MaxLength(140, ErrorMessage = "Maximum length for the Post Body is 140 characters.")]
    public string? Content { get; set;}
    public DateTimeOffset? CreatedAt { get; set; }
    public bool? IsLiked { get; set; }

    //[ForeignKey(nameof(UserId))]
    public Guid UserId { get; set; }

    //Reference Navigational Property
    public User? User { get; set; }

    //Collection Navigational Property
    public List<Like> Likes { get; set; } = new();

}
