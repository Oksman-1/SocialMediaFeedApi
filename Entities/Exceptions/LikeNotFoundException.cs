using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class LikeNotFoundException : NotFoundException
{
	public LikeNotFoundException() : base($"The like doesn't exist in the database")
	{
	}
}