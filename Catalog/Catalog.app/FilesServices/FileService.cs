using Catalog.application.FilesServices;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Catalog.Application.FilesServices
{
	public class FileService : IFileService
	{
		public async Task<string> SaveFileAsync(byte[] fileBytes, string extension)
		{
			var root = Directory.GetCurrentDirectory(); // مسار تشغيل التطبيق
			var folderPath = Path.Combine(root, "wwwroot", "images");

			if (!Directory.Exists(folderPath))
				Directory.CreateDirectory(folderPath);

			var fileName = $"{Guid.NewGuid()}{extension}";
			var filePath = Path.Combine(folderPath, fileName);

			await File.WriteAllBytesAsync(filePath, fileBytes);

			return fileName;
		}
	}
}
