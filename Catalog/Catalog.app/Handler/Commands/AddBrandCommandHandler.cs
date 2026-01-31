using AutoMapper;
using Catalog.application.Commands;
using Catalog.core.Entities;
using Catalog.core.Repository;

using MediatR;


public class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, bool>
{
	private readonly IBrandRepository _brandRepository;
	private readonly IMapper _mapper;

	public AddBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
	{
		_mapper = mapper;
		_brandRepository = brandRepository;
	}

	public async Task<bool> Handle(AddBrandCommand request, CancellationToken cancellationToken)
	{
		var brandEntity = _mapper.Map<ProductBrand>(request);

		var result = await _brandRepository.CreateProductBrand(brandEntity);

		return result != null;
	}
}
