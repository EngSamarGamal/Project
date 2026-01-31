using Catalog.application.FilesServices;
using Catalog.application.Mapper;
using Catalog.Application.FilesServices;
using Catalog.core.Repository;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.OpenApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Catalog API",
		Version = "v1",
		Description = "This is API for Catalog microservice in ecommerce application",
		Contact = new OpenApiContact
		{
			Name = "samar gamal",
			Email = "samaramer123922@gmail.com",
			Url = new Uri("https://yourwebsite.com")
		}
	});
});

// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(ProductMappingProfile).Assembly);

// MediatR (سكان الـ handlers)
builder.Services.AddMediatR(cfg =>
{
	cfg.RegisterServicesFromAssembly(typeof(ProductMappingProfile).Assembly);
});

// Mongo Context
builder.Services.AddSingleton<CatalogContext>();

// DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandRepository, ProductRepository>();
builder.Services.AddScoped<ITypesRepository, ProductRepository>();
builder.Services.AddScoped<IFileService, FileService>();

// Versioning
builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
});

var app = builder.Build();

// ✅ خلي Swagger شغال دائمًا (على الأقل لحد ما نتأكد)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
	c.RoutePrefix = "swagger";
});

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
