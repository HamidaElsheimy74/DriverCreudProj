namespace DriverCrudTestApi.Helpers.HelperModels
{
	public class ErrorMessageGenerator
	{
		private static Dictionary<Enum, string> Errors = new Dictionary<Enum, string>
		{
			{
				ErrorMessageGeneratorEnum.internalServerError,
				"An error occured while processing your request : "
			},
			{
				ErrorMessageGeneratorEnum.InvalidFirstName,
				"Invalid first name."
			},
			{
				ErrorMessageGeneratorEnum.EmptyFirstName,
				"The first name is empty or null."
			},
			{
				ErrorMessageGeneratorEnum.InvalidLastName,
				"Invalid last name."
			},
			{
				ErrorMessageGeneratorEnum.EmptyLastName,
				"The last name is empty or null."
			},
			{
				ErrorMessageGeneratorEnum.InvalidEmail,
				"Invalid email address."
			},
			{
				ErrorMessageGeneratorEnum.EmptyEmail,
				"The Email address is empty or null."
			},
			{
				ErrorMessageGeneratorEnum.InvalidPhoneNumber,
				"Invalid Phone number."
			},
			{
				ErrorMessageGeneratorEnum.EmptyPhoneNumber,
				"The phone number is empty or null."
			},
			{
				ErrorMessageGeneratorEnum.InvalidModel,
				"Model is not valid, please check your data."
			},
			{
				ErrorMessageGeneratorEnum.itemNotExist,
				"This driver is not exist."
			},
			{
				ErrorMessageGeneratorEnum.InvalidId,
				"Invalid Id, it must be provided and greater than 0."
			}
			,
			{
				ErrorMessageGeneratorEnum.UserExist,
				"This driver is already exist."
			},
			{
				ErrorMessageGeneratorEnum.FailedToAdd,
				"An error occured while adding driver data."
			},
			{
				ErrorMessageGeneratorEnum.FailedToUpdate,
				"An error occured while updating driver data."
			},
			{
				ErrorMessageGeneratorEnum.FailedToDelete,
				"An error occured while deleting driver data."
			},
			{
				ErrorMessageGeneratorEnum.FailedToGet,
				"An error occured while getting driver data."
			}
		};

		public static string GenerateErrorMessage(ErrorMessageGeneratorEnum errorMessageGeneratorEnum)
		{
			return Errors[errorMessageGeneratorEnum];
		}
	}
}
