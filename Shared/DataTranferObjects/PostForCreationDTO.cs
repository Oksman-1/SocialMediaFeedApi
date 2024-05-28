using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record PostForCreationDTO
{
    //public Guid PostId { get; set; }

    //[Required(ErrorMessage = "Post Title is a required field.")]
    //[MaxLength(60, ErrorMessage = "Maximum length for the Post Title is 60 characters.")]
    //public string? PostTitle { get; set; }

    //[Required(ErrorMessage = "Post Body is a required field.")]
    //[MaxLength(140, ErrorMessage = "Maximum length for the Post Body is 140 characters.")]
    public string? Content { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }

    //[ForeignKey(nameof(UserId))]
   // public Guid UserId { get; set; }

    ////Reference Navigational Property
    //public UserDTO? User { get; set; }

    //Collection Navigational Property
    //public List<LikeDTO> Likes { get; set; } = new();
}
