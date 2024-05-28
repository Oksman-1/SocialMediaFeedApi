using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
	public sealed class UserFollowingBadRequestException : BadRequestException
    {
		public UserFollowingBadRequestException() : base("A user cannot follow themselves.")
		{
		}
	}

}
