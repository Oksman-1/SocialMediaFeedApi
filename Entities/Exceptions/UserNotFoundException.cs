using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class UserNotFoundException : NotFoundException
{
	public UserNotFoundException(Guid userId) : base($"The User with ID: {userId} doesn't exist in the database.")
	{
	}
}
