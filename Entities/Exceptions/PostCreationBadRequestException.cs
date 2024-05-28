using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
	public sealed class PostCreationBadRequestException : BadRequestException
    {
		public PostCreationBadRequestException(Guid postId) : base($"The post with {postId} was not created by the user")
		{
		}
	}

}
