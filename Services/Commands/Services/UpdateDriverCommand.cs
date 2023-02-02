using DriverCrudTestApi.Helpers.HelperModels;
using DriverCrudTestApi.Models;
using DriverCrudTestApi.Services.Commands.Interfaces;
using System.Text.RegularExpressions;

namespace DriverCrudTestApi.Services.Commands.Services
{
	public class UpdateDriverCommand : IUpdateDriverCommand
	{
		private readonly DriverTestDbContext _dbContext;
		public UpdateDriverCommand(DriverTestDbContext driverTestDbContext) 
		{
			_dbContext= driverTestDbContext;
		}
		/// <summary>
		/// updates driver data
		/// </summary>
		/// <param name="model"></param>
		public DriverCrudResponseModel Update(UpdateDriverRequestModel model)
		{
			try
			{
				var driver = _dbContext.Drivers.FirstOrDefault(x => x.Id == model.Id);
				if (driver != null)
				{
					driver.FirstName = model.FirstName;
					driver.LastName = model.LastName;
					driver.Email = model.Email;
					driver.PhoneNumber = model.PhoneNumber;
					driver.UpdatedDate = DateTime.UtcNow;

					var isUpdated = _dbContext.Update(driver);
					var savedChanges=_dbContext.SaveChanges();
					if (isUpdated.Entity != null && savedChanges>0)
					{
						return new DriverCrudResponseModel()
						{
							HasError = false,
							Data = isUpdated.Entity.Id
						};
					}
					else
					{
						return new DriverCrudResponseModel()
						{
							HasError = true,
							ErrorMessage = ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.FailedToUpdate)
						};
					}
				}
				else
				{
					return new DriverCrudResponseModel()
					{
						HasError = true,
						ErrorMessage = ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.itemNotExist)
					};
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
