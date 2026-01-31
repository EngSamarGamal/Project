using Catalog.application.Responses;
using MediatR;
namespace Catalog.application.Queries
{
	public class GetAllTypesQuery : IRequest<IEnumerable<TypeResponseDto>>	
	{
	}
}
