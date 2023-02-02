namespace DriverCrudTestApi.Helpers.HelperModels
{
	public enum ErrorMessageGeneratorEnum
	{
		internalServerError = 1,
		InvalidFirstName = 2,
		EmptyFirstName = 3,
		InvalidLastName = 4,
		EmptyLastName = 5,
		InvalidEmail = 6,
		EmptyEmail = 7,
		InvalidPhoneNumber = 8,
		EmptyPhoneNumber = 9,
		InvalidModel = 10,
		itemNotExist = 11,
		InvalidId = 12,
		UserExist = 13,
		FailedToAdd=14,
		EmptyId=15,
		FailedToUpdate=16,
		FailedToDelete=17,
		FailedToGet=18,
	}
}
