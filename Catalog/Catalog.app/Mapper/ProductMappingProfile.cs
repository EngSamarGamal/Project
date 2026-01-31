using AutoMapper;
using Catalog.application.Commands;
using Catalog.application.Responses;
using Catalog.core.Entities;
using Catalog.Core.Entities;

namespace Catalog.application.Mapper
{
	public class ProductMappingProfile : Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<AddBrandCommand, ProductBrand>();
	
			CreateMap<ProductBrand, BrandResponseDto>().ReverseMap();
			CreateMap<Product, ProductResponseDto>().ReverseMap();
			CreateMap<ProductType, TypeResponseDto>().ReverseMap();

		}
	}
}
