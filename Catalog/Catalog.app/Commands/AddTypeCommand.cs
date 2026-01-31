using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.application.Commands
{
	public class AddTypeCommand : IRequest<bool>
	{
		public string Name { get; set; }

	}
}
