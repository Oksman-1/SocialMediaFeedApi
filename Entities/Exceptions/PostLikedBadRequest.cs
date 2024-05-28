using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class PostLikedBadRequest : BadRequestException
{
	public PostLikedBadRequest(Guid userId) : base($"This post has already been liked by the user with ID: {userId}!")
	{

	}
}
