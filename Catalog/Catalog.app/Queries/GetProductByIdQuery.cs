using Catalog.application.Responses;
using MediatR;

public class GetProductByIdQuery : IRequest<ProductResponseDto>
{
	public string Id { get; }

	public GetProductByIdQuery(string id)
	{
		Id = id;
	}
}
