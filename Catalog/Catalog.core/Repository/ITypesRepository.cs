using Catalog.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.core.Repository
{
	public interface ITypesRepository
	{
		Task<ProductType> CreateProductType(ProductType productType);
		Task<IEnumerable<ProductType>> GetAllProductType();
	}
}
