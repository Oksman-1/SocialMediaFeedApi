using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class User
{
    //PK
    public Guid UserId { get; set; }
    public string? Username { get; set; }

    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public string? Email { get; set; }

    [Url(ErrorMessage = "URL is not valid")]
    public string? Website { get; set; }

    //Collection Navigational Properties
    public List<Post> Posts { get; set; } = new();
    public List<Like> Likes { get; set; } = new();
    public List<UserFollowed> UsersFollowed { get; set; } = new();
    

}
