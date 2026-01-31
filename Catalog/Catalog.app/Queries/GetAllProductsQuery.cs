using Catalog.application.Responses;
using MediatR;
namespace Catalog.application.Queries
{
	public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponseDto>>	
	{
	}
}
