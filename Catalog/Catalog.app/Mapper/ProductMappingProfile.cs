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
			// Mappings الموجودة
			CreateMap<Product, ProductResponseDto>().ReverseMap();
			CreateMap<ProductBrand, BrandResponseDto>().ReverseMap();
			CreateMap<ProductType, TypeResponseDto>().ReverseMap();

			// أضف الـ mappings دي 👇
			CreateMap<AddProductCommand, Product>().ReverseMap();
			CreateMap<AddBrandCommand, ProductBrand>().ReverseMap();
			CreateMap<AddTypeCommand, ProductType>().ReverseMap(); // ← ده اللي ناقص!	CreateMap<AddBrandCommand, ProductBrand>();
			CreateMap<AddTypeCommand, ProductType>();

			CreateMap<ProductBrand, BrandResponseDto>().ReverseMap();
			CreateMap<Product, ProductResponseDto>().ReverseMap();
			CreateMap<ProductType, TypeResponseDto>().ReverseMap();

		}
	}
}
