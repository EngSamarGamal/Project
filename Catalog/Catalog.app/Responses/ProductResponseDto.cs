using Catalog.core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.application.Responses
{
	public class ProductResponseDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Summary { get; set; }
		public string ImageFile { get; set; }
		public decimal Price { get; set; }  // ✅ بدون [BsonRepresentation]

		// ✅ استخدم DTOs بدل الـ Entities
		public BrandResponseDto Brand { get; set; }
		public TypeResponseDto Type { get; set; }
	}
}
