using Catalog.core.Entities;
using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
	public class CatalogContext
	{
		//inject configuration to read connection string and db name	
		public IMongoCollection<Product> Products { get; }
		public IMongoCollection<ProductBrand> Brands { get; }
		public IMongoCollection<ProductType> Types { get; }

		public CatalogContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
			var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

			Brands = database.GetCollection<ProductBrand>(
				configuration["DatabaseSettings:BrandsCollection"]);

			Types = database.GetCollection<ProductType>(
				configuration["DatabaseSettings:TypesCollection"]);

			Products = database.GetCollection<Product>(
				configuration["DatabaseSettings:ProductsCollection"]);

		
		}
	}
}
