using DriverCrudTestApi.Helpers.HelperModels;
using DriverCrudTestApi.Models;
using DriverCrudTestApi.Services.Commands.Interfaces;
using System.Text.RegularExpressions;

namespace DriverCrudTestApi.Services.Commands.Services
{
	public class CreateDriverCommand: ICreateDriverCommand
	{
		private readonly DriverTestDbContext _dbContext;
		public CreateDriverCommand( DriverTestDbContext driverTestDbContext)
		{ 
			_dbContext = driverTestDbContext;
		}

		/// <summary>
		/// Add new applicant 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public DriverCrudResponseModel Create(CreateDriverRequestModel model)
		{
			try
			{
				
				var isExist = _dbContext.Drivers.FirstOrDefault(x => x.PhoneNumber == model.PhoneNumber);

				if (isExist != null)
				{
					return new DriverCrudResponseModel()
					{
						HasError = true,
						ErrorMessage = ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.UserExist)
					};
				}

				var driver = new Drivers()
				{
					CreationDate = DateTime.UtcNow,
					FirstName = model.FirstName,
					LastName = model.LastName,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber,
				};
				var isAdded = _dbContext.Drivers.Add(driver);
				var savedChanges=_dbContext.SaveChanges();
				if (isAdded != null && savedChanges>0)
				{
					return new DriverCrudResponseModel()
					{
						HasError = false,
						Data = isAdded.Entity.Id
					};
				}
				else
					return new DriverCrudResponseModel()
					{
						HasError = true,
						ErrorMessage= ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.FailedToAdd)
					};
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
