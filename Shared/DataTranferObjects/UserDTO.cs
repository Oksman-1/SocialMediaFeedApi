using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record UserDTO
{
    public Guid UserId { get; set; }
    public string? Username { get; set; }

    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public string? Email { get; set; }

    [Url(ErrorMessage = "URL is not valid")]
    public string? Website { get; set; }

    //Collection Navigational Properties
    public List<PostDTO> Posts { get; set; } = new();
    public List<LikeDTO> Likes { get; set; } = new();
    public List<UserFollowedDTO>? UsersFollowed { get; set; } = new();
    //public List<UserFollowedDTO>? UsersFollowing { get; set; } = new();
}
