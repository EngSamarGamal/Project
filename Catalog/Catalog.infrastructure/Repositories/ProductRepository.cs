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
			// جيب الـ Products
			var products = await _context.Products
				.Find(Builders<Product>.Filter.Empty)
				.ToListAsync();

			if (!products.Any())
				return products;  // ✅ لو مفيش products، ارجع فاضي

			// ✅ جيب الـ IDs اللي محتاجها بس (مش كل الـ Brands والـ Types)
			var brandIds = products
				.Where(p => !string.IsNullOrEmpty(p.BrandId))
				.Select(p => p.BrandId)
				.Distinct()
				.ToList();

			var typeIds = products
				.Where(p => !string.IsNullOrEmpty(p.TypeId))
				.Select(p => p.TypeId)
				.Distinct()
				.ToList();

			// ✅ جيب الـ Brands اللي محتاجها بس (مش كلهم!)
			var brands = brandIds.Any()
				? await _context.Brands
					.Find(Builders<ProductBrand>.Filter.In(b => b.Id, brandIds))
					.ToListAsync()
				: new List<ProductBrand>();

			// ✅ جيب الـ Types اللي محتاجها بس
			var types = typeIds.Any()
				? await _context.Types
					.Find(Builders<ProductType>.Filter.In(t => t.Id, typeIds))
					.ToListAsync()
				: new List<ProductType>();

			// ✅ استخدم Dictionary عشان الـ Lookup يبقى O(1) بدل O(n)
			var brandDictionary = brands.ToDictionary(b => b.Id);
			var typeDictionary = types.ToDictionary(t => t.Id);

			// ربط الـ Products بالـ Brands والـ Types
			foreach (var product in products)
			{
				if (!string.IsNullOrEmpty(product.BrandId) && brandDictionary.ContainsKey(product.BrandId))
				{
					product.Brand = brandDictionary[product.BrandId];
				}

				if (!string.IsNullOrEmpty(product.TypeId) && typeDictionary.ContainsKey(product.TypeId))
				{
					product.Type = typeDictionary[product.TypeId];
				}
			}

			return products;
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
