using Catalog.api.Controllers;
using Catalog.application.Commands;
using Catalog.application.Queries;
using Catalog.application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
	public class CatalogController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CatalogController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("[action]/{id}", Name = "GetProductById")]
		[ProducesResponseType(typeof(ProductResponseDto), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<ActionResult<ProductResponseDto>> GetProductById(string id)
		{
			var query = new GetProductByIdQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpPost]
		[Route("CreateProduct")]
		[ProducesResponseType(typeof(ProductResponseDto), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromForm] AddProductCommand productCommand )
		{
			var result = await _mediator.Send(productCommand);
			return Ok(result);
		}
		[HttpPost]
		[Route("CreateProductBrand")]
		[ProducesResponseType(typeof(BrandResponseDto), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<BrandResponseDto>> CreateProductBrand([FromBody] AddBrandCommand brandCommand)
		{
			var result = await _mediator.Send(brandCommand);
			return Ok(result);
		}
		[HttpGet]
		[Route("GetAllProductBrands")]
		[ProducesResponseType(typeof(IEnumerable<BrandResponseDto>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<BrandResponseDto>>> GetAllProductBrands()
		{
			var result = await _mediator.Send(new GetAllBrandsQuery());
			return Ok(result);
		}
		[HttpGet]
		[Route("GetAllProduct")]
		[ProducesResponseType(typeof(IEnumerable<ProductResponseDto>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProduct()
		{
			var result = await _mediator.Send(new GetAllProductsQuery());
			return Ok(result);
		}


		//[HttpPut]
		//[Route("UpdateProduct")]
		//[ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
		//public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand productCommand)
		//{
		//	var result = await _mediator.Send(productCommand);
		//	return Ok(result);
		//}

		//[HttpDelete]
		//[Route("{id}", Name = "DeleteProduct")]
		//[ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
		//public async Task<ActionResult<bool>> DeleteProduct(string id)
		//{
		//	var command = new DeleteProductCommand(id);
		//	var result = await _mediator.Send(command);
		//	return Ok(result);
		//}

	}
}
