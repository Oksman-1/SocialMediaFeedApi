using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class PostByUserNotFoundException : NotFoundException
{
	public PostByUserNotFoundException(Guid postId) : base($"The user with ID: {postId} doesn't have such a post")
	{
	}
}