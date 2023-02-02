using DriverCrudTestApi.Helpers.HelperModels;
using DriverCrudTestApi.Models;
using DriverCrudTestApi.Services.Queries.Interfacses;

namespace DriverCrudTestApi.Services.Queries.Services
{
	public class GetDriverListQuery : IGetDriverListQuery
	{

		private readonly DriverTestDbContext _dbContext;
		public GetDriverListQuery(DriverTestDbContext dbContext)
		{
			_dbContext= dbContext;
		}

		/// <summary>
		/// Get all drivers from db
		/// </summary>
		/// <returns></returns>
		public DriverCrudResponseModel GetDriverList()
		{
			try
			{
				var drivers =_dbContext.Drivers.ToList();
				return new DriverCrudResponseModel()
				{
					HasError = false,
					Data = drivers
				};
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
