using AutoMapper;
using Catalog.application.Commands;
using Catalog.application.FilesServices;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;


public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
{
	private readonly IProductRepository _productRepository;
	private readonly IMapper _mapper;
	private readonly IFileService _FileService;


	public AddProductCommandHandler(
		IMapper mapper,
		IProductRepository productRepository, IFileService fileService)
	{
		_mapper = mapper;
		_productRepository = productRepository;
		_FileService = fileService;
	}



public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
{
	var productEntity = _mapper.Map<Product>(request);



	var result = await _productRepository.CreateProduct(productEntity);
	return result != null;
}
}
