using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record UserForCreationDTO
{
    public string? Username { get; set; }

    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public string? Email { get; set; }

    [Url(ErrorMessage = "URL is not valid")]
    public string? Website { get; set; }

    ////Collection Navigational Properties
    //public List<Post> Posts { get; set; } = new();
    //public List<Like> Likes { get; set; } = new();
    //public List<UserFollowed>? UsersFollowed { get; set; } = new();
    //public List<UserFollowed>? UsersFollowing { get; set; } = new();

}
