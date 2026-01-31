using AutoMapper;
using Catalog.application.Commands;
using Catalog.core.Entities;
using Catalog.core.Repository;

using MediatR;


public class AddTypeCommandHandler : IRequestHandler<AddTypeCommand, bool>
{
	private readonly ITypesRepository _typesRepository;
	private readonly IMapper _mapper;

	public AddTypeCommandHandler(IMapper mapper, ITypesRepository typesRepository)
	{
		_mapper = mapper;
		_typesRepository = typesRepository;	
	}

	public async Task<bool> Handle(AddTypeCommand request, CancellationToken cancellationToken)
	{
		var brandEntity = _mapper.Map<ProductType>(request);

		var result = await _typesRepository.CreateProductType(brandEntity);

		return result != null;
	}
}
