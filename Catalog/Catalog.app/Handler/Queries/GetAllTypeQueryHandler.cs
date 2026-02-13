using AutoMapper;
using Catalog.application.Queries;
using Catalog.application.Responses;
using Catalog.core.Repository;
using MediatR;

namespace Catalog.application.Handler.Queries
{
	public class GetAllTypeQueryHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<TypeResponseDto>>
	{
		private readonly ITypesRepository _typesRepository;
		private readonly IMapper _Mapper;

		public GetAllTypeQueryHandler(IMapper mapper, ITypesRepository typesRepository)
		{
			_Mapper = mapper;
			_typesRepository = typesRepository;	
		}

		public async Task<IEnumerable<TypeResponseDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
		{
			var types = await _typesRepository.GetAllProductType();  // Add await here
			var typeDtos = _Mapper.Map<IEnumerable<TypeResponseDto>>(types);
			return typeDtos;  // No need for Task.FromResult when using async/await
		}
	}
}
