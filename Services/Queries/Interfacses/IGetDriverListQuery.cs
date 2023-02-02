using DriverCrudTestApi.Helpers.HelperModels;

namespace DriverCrudTestApi.Services.Queries.Interfacses
{
	public interface IGetDriverListQuery
	{
		DriverCrudResponseModel GetDriverList();
	}
}
