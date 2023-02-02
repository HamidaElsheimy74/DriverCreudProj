using DriverCrudTestApi.Helpers.HelperModels;

namespace DriverCrudTestApi.Services.Commands.Interfaces
{
    public interface ICreateDriverCommand
    {
		DriverCrudResponseModel Create(CreateDriverRequestModel model);
	}
}
