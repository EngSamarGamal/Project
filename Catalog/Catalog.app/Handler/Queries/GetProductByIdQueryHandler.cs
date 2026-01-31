using AutoMapper;
using Catalog.application.Responses;
using Catalog.Core.Repositories;
using MediatR;


namespace Catalog.application.Handler.Queries
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDto>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _Mapper;

		public GetProductByIdQueryHandler(IProductRepository productRepository,IMapper mapper)
		{
			_productRepository = productRepository;
			_Mapper = mapper;
		}


		public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetProductById(request.Id);

			if (product == null)
				return null;

			return _Mapper.Map<ProductResponseDto>(product);
		}
	}
}
