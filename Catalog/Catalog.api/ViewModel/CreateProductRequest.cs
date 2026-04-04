namespace Catalog.api.ViewModel
{
	public class CreateProductRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Summary { get; set; }
		public IFormFile Image { get; set; }  // ✅ هنا بس
		public string Url { get; set; }  // ✅ هنا بس

		public decimal Price { get; set; }
		public string BrandId { get; set; }
		public string TypeId { get; set; }
	}
}
