using AutoMapper;
using Catalog.application.Queries;
using Catalog.application.Responses;
using Catalog.Core.Repositories;
using MediatR;


namespace Catalog.application.Handler.Queries
{
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponseDto>>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _Mapper;

		public GetAllProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
		{
			_Mapper = mapper;
			_productRepository = productRepository;
		}
		public async Task<IEnumerable<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllProducts();
			var productsDto = _Mapper.Map<IEnumerable<ProductResponseDto>>(products);
			return productsDto;		
		}
	}
}
