using DriverCrudTestApi.Helpers.HelperModels;

namespace DriverCrudTestApi.Services.Commands.Interfaces
{
	public interface IDeleteDriverCommand
	{
		DriverCrudResponseModel Delete(long driverId);
	}
}
