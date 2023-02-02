using DriverCrudTestApi.Helpers.HelperModels;
using DriverCrudTestApi.Services.Commands.Interfaces;
using DriverCrudTestApi.Services.Commands.Services;
using DriverCrudTestApi.Services.Queries.Interfacses;
using DriverCrudTestApi.Services.Queries.Services;
using DriverCrudTestApi.Validators;
using FluentValidation;

namespace DriverCrudTestApi.Helpers.DI
{
	public static class DI
	{
		internal static IServiceCollection DIConfigureServices(this IServiceCollection services)
		{
			//services register
			services.AddScoped<ICreateDriverCommand, CreateDriverCommand>();
			services.AddScoped<IUpdateDriverCommand, UpdateDriverCommand>();
			services.AddScoped<IDeleteDriverCommand, DeleteDriverCommand>();
			services.AddScoped<IGetDriverDetailsQuery, GetDriverDetailsQuery>();
			services.AddScoped<IGetDriverListQuery, GetDriverListQuery>();



			//validator register
			services.AddScoped<IValidator<CreateDriverRequestModel>, CreateDriverRequestModelValidator>();
			services.AddScoped<IValidator<UpdateDriverRequestModel>, UpdateDriverRequestModelValidator>();


			return services;
		}
	}
}
