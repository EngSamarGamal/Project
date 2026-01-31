using AutoMapper;
using Catalog.application.Queries;
using Catalog.application.Responses;
using Catalog.core.Repository;
using MediatR;


namespace Catalog.application.Handler.Queries
{
	public class GetAllBrandsQueryHandler:IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandResponseDto>>
	{
		private readonly IBrandRepository _BrandRepository;
		private readonly IMapper _Mapper;

		public GetAllBrandsQueryHandler(IMapper mapper,IBrandRepository brandRepository)
		{
			_Mapper = mapper;
			_BrandRepository = brandRepository;
		}


		public async Task<IEnumerable<BrandResponseDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
		{
			var brands = await _BrandRepository.GetAllProductBrands();
			var brandDtos = _Mapper.Map<IEnumerable<BrandResponseDto>>(brands);
			return brandDtos;	
		}
	}
}
