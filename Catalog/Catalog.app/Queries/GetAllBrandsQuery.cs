using Catalog.application.Responses;
using MediatR;
namespace Catalog.application.Queries
{
	public class GetAllBrandsQuery:IRequest<IEnumerable<BrandResponseDto>>	
	{
	}
}
