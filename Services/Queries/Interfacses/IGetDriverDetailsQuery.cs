using DriverCrudTestApi.Helpers.HelperModels;

namespace DriverCrudTestApi.Services.Queries.Interfacses
{
	public interface IGetDriverDetailsQuery
	{
		DriverCrudResponseModel GetDriverDetails(long driverId);
	}
}
