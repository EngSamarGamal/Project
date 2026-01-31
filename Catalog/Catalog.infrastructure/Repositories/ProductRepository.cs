using Catalog.core.Entities;
using Catalog.core.Repository;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
	public class ProductRepository : IBrandRepository, IProductRepository, ITypesRepository
	{
		private readonly CatalogContext _context;

		public ProductRepository(CatalogContext context)
		{
			_context = context;
		}

		#region Products

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			return await _context.Products.Find(p => true).ToListAsync();
		}

		public async Task<Product> GetProductById(string id)
		{
			return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProductsByName(string name)
		{
			return await _context.Products
				.Find(p => p.Name.ToLower().Contains(name.ToLower()))
				.ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetAllProductsByBrand(string name)
		{
			return await _context.Products
				.Find(p => p.Brand.Name.ToLower().Contains(name.ToLower()))
				.ToListAsync();
		}

		public async Task<Product> CreateProduct(Product product)
		{
			await _context.Products.InsertOneAsync(product);
			return product;
		}

		public async Task<bool> UpdateProduct(Product product)
		{
			var result = await _context.Products
				.ReplaceOneAsync(p => p.Id == product.Id, product);

			return result.IsAcknowledged && result.ModifiedCount > 0;
		}

		public async Task<bool> DeleteProduct(string id)
		{
			var result = await _context.Products
				.DeleteOneAsync(p => p.Id == id);

			return result.IsAcknowledged && result.DeletedCount > 0;
		}

		#endregion

		#region Brands

		public async Task<IEnumerable<ProductBrand>> GetAllProductBrands()
		{
			return await _context.Brands.Find(b => true).ToListAsync();
		}

		public async Task<ProductBrand> CreateProductBrand(ProductBrand productBrand)
		{
			await _context.Brands.InsertOneAsync(productBrand);
			return productBrand;
		}

		#endregion

		#region Types

		public async Task<IEnumerable<ProductType>> GetAllProductType()
		{
			return await _context.Types.Find(t => true).ToListAsync();
		}

		public async Task<ProductType> CreateProductType(ProductType productType)
		{
			await _context.Types.InsertOneAsync(productType);
			return productType;
		}

		#endregion
	}
}
