namespace DriverCrudTestApi.Helpers.HelperModels
{
	public class DriverCrudResponseModel
	{
		public bool HasError { set; get; }
		public string ErrorMessage { set; get; }
		public object Data { set; get; }
	}
}
