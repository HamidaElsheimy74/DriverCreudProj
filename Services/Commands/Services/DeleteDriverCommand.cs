using DriverCrudTestApi.Helpers.HelperModels;
using DriverCrudTestApi.Models;
using DriverCrudTestApi.Services.Commands.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DriverCrudTestApi.Services.Commands.Services
{
	public class DeleteDriverCommand : IDeleteDriverCommand
	{

		private readonly DriverTestDbContext _dbContext;
		public DeleteDriverCommand(DriverTestDbContext dbContext) 
		{
			_dbContext= dbContext;
		}
		/// <summary>
		/// Deletes driver from db
		/// </summary>
		/// <param name="driverId"></param>
		/// <returns></returns>
		public DriverCrudResponseModel Delete(long driverId)
		{
			try
			{
				if (driverId > 0)
				{
					var driverExist =_dbContext.Drivers.FirstOrDefault(x => x.Id == driverId);
					if (driverExist==null)
					{
						return new DriverCrudResponseModel()
						{
							HasError = true,
							ErrorMessage = ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.itemNotExist)
						};
					}
					else
					{

						var isDeleted=_dbContext.Drivers.Remove(driverExist);
						var savedChanges=_dbContext.SaveChanges();
						if (isDeleted != null && savedChanges > 0)
						{
							return new DriverCrudResponseModel()
							{
								HasError = false,
								Data = true
							};
						}
						else
						{
							return new DriverCrudResponseModel()
							{
								HasError = true,
								ErrorMessage = ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.FailedToDelete)
							};
						}

					}
				}
				else
				{
					return new DriverCrudResponseModel()
					{
						HasError = true,
						Data = ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidId)
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
