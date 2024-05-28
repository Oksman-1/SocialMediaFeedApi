using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
	public sealed class UserAlreadyFollowingBadRequestException : BadRequestException
    {
		public UserAlreadyFollowingBadRequestException() : base("This user is already being followed by you")
		{
		}
	}

}
