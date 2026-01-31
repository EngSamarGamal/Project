using MediatR;


namespace Catalog.application.Commands
{
	public class AddProductCommand : IRequest<bool>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Summary { get; set; }
		public string ImageFile { get; set; }
	//	public IFormFile Image { get; set; }

		public decimal Price { get; set; }

		public string BrandId { get; set; }

		public string TypeId { get; set; }


	

	}
}
