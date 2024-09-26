using Microsoft.EntityFrameworkCore;
using Restapi_PersonController.Model.Context;
using Restapi_PersonController.Business;
using Restapi_PersonController.Business.Implementations;
using Restapi_PersonController.Repository;
using Serilog;
using Microsoft.Data.SqlClient;
using EvolveDb;
using Restapi_PersonController.Repository.Generic;
using Microsoft.Net.Http.Headers;
using Restapi_PersonController.Hypermedia.Filters;
using Restapi_PersonController.Hypermedia.Enricher;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
	builder.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader();
}));

builder.Services.AddControllers();

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

var connection = builder.Configuration["SqlServerConnection:SqlServerConnectionString"];
builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connection));

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

builder.Services.AddMvc(OptionsBuilderConfigurationExtensions =>
{
	//Aceitar a propriedade que vem como default no header do browser
	OptionsBuilderConfigurationExtensions.RespectBrowserAcceptHeader = true;
	OptionsBuilderConfigurationExtensions.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
	OptionsBuilderConfigurationExtensions.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
}).AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BooksEnricher());
builder.Services.AddSingleton(filterOptions);

builder.Services.AddApiVersioning();

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1",
		new OpenApiInfo
		{
			Title = "REST APIS's From 0 to Azure with ASP.NET Core 8 and Docker",
			Version = "v1",
			Description = "API RESTful developed in course 'REST APIS's From 0 to Azure with ASP.NET Core 8 and Docker'",
			Contact = new OpenApiContact
			{
				Name = "Vinicius Rondini Ferreira",
				Url = new Uri("https://github.com/VRondini")
			}
        });
});

//Injeção de dependencia
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", 
		"REST APIS's From 0 to Azure with ASP.NET Core 8 and Docker - v1");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

app.Run();
void MigrateDatabase(string connection)
{
	try
	{
        var evolveConnection = new SqlConnection(connection);
		var evolve = new Evolve(evolveConnection, Log.Information)
		{
			Locations = new List<string> { "db/migrations", "db/dataset" },
			IsEraseDisabled = true,
		};
		evolve.Migrate();
    }
	catch (Exception ex)
	{
		Log.Error("Database migration failed", ex);
		throw;
	}
}