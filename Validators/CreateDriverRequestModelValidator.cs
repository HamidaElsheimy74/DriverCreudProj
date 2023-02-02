using DriverCrudTestApi.Helpers.HelperModels;
using FluentValidation;

namespace DriverCrudTestApi.Validators
{
	public class CreateDriverRequestModelValidator : AbstractValidator<CreateDriverRequestModel>
	{
		public CreateDriverRequestModelValidator()
		{
			RuleFor(x => x.FirstName).
				NotNull().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyFirstName))
				.NotEmpty().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyFirstName));
			RuleFor(x => x.LastName)
				.NotNull().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyLastName))
				.NotEmpty().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyLastName));
			RuleFor(x => x.Email)
				.NotNull().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyEmail))
				.NotEmpty().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyEmail))
				.Matches(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")
				.WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidId));
			RuleFor(x => x.PhoneNumber)
				.NotNull().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyPhoneNumber))
				.NotEmpty().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyPhoneNumber))
				.Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidPhoneNumber));
		}
	}
}
