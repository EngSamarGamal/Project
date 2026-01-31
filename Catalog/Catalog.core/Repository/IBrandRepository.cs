using Catalog.core.Entities;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.core.Repository
{
	public interface IBrandRepository
	{
		 Task<ProductBrand> CreateProductBrand(ProductBrand productBrand);
		Task<IEnumerable<ProductBrand>> GetAllProductBrands();

	}
}
