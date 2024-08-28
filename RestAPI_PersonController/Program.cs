using Microsoft.EntityFrameworkCore;
using Restapi_PersonController.Model.Context;
using Restapi_PersonController.Business;
using Restapi_PersonController.Business.Implementations;
using Restapi_PersonController.Repository;
using Serilog;
using Microsoft.Data.SqlClient;
using EvolveDb;
using Restapi_PersonController.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

var connection = builder.Configuration["SqlServerConnection:SqlServerConnectionString"];
builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connection));

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

builder.Services.AddApiVersioning();

//Injeção de dependencia
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

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