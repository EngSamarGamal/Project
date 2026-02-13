using Catalog.core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities
{
	[BsonIgnoreExtraElements]  // ✅ ضيف السطر ده

	public class Product : BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string Summary { get; set; }

		public string ImageFile { get; set; }

		[BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
		public decimal Price { get; set; }
		[BsonRepresentation(BsonType.ObjectId)]
		public string BrandId { get; set; }

		[BsonRepresentation(BsonType.ObjectId)]
		public string TypeId { get; set; }
		[BsonIgnore]
		public ProductBrand Brand { get; set; }

		[BsonIgnore]
		public ProductType Type { get; set; }
	}
}
