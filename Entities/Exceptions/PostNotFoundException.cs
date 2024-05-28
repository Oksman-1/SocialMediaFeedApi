using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class PostNotFoundException : NotFoundException
{
	public PostNotFoundException(Guid postId) : base($"The post with ID: {postId} doesn't exist in the database")
	{
	}
}