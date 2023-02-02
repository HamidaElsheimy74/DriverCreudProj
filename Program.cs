using DriverCrudTestApi.Helpers.DI;
using DriverCrudTestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
				.AddJsonOptions(option => {
					option.JsonSerializerOptions.PropertyNamingPolicy = null;
				});
builder.Services.AddDbContext<DriverTestDbContext>(options =>
	options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]).EnableSensitiveDataLogging());

//Register DI
builder.Services.DIConfigureServices();
//services.AddScoped<IApplicantServices, ApplicantServices>();
//services.AddScoped<IRepository<Applicant>, Repository<Applicant>>();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "DriverCrudTestApi", Version = "v1" });
	c.IncludeXmlComments(string.Format(@"{0}\DriverCrudTestApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
