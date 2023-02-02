using DriverCrudTestApi.Helpers.HelperModels;
using DriverCrudTestApi.Models;
using DriverCrudTestApi.Services.Queries.Interfacses;

namespace DriverCrudTestApi.Services.Queries.Services
{
	public class GetDriverDetailsQuery : IGetDriverDetailsQuery
	{
		private readonly DriverTestDbContext _dbContext;
		public GetDriverDetailsQuery(DriverTestDbContext dbContext)
		{
			_dbContext= dbContext;
		}
		/// <summary>
		/// Get driver by its Id
		/// </summary>
		/// <param name="driverId"></param>
		/// <returns></returns>
		public DriverCrudResponseModel GetDriverDetails(long driverId)
		{
			try
			{
				if (driverId > 0)
				{
					var driver =_dbContext.Drivers.FirstOrDefault(x => x.Id == driverId);
					if (driver != null)
					{
						return new DriverCrudResponseModel()
						{
							HasError = false,
							Data = driver
						};
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
				else
				{
					return new DriverCrudResponseModel()
					{
						HasError = true,
						ErrorMessage = ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidId)
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
