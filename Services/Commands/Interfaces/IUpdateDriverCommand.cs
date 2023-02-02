using DriverCrudTestApi.Helpers.HelperModels;

namespace DriverCrudTestApi.Services.Commands.Interfaces
{
	public interface IUpdateDriverCommand
	{
		DriverCrudResponseModel Update(UpdateDriverRequestModel model);
	}
}
