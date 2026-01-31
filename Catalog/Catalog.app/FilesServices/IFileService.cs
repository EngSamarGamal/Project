using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.application.FilesServices
{
	public interface IFileService
	{
		Task<string> SaveFileAsync(byte[] fileBytes, string extension);

	}
}
