using DriverCrudTestApi.Helpers.HelperModels;
using FluentValidation;

namespace DriverCrudTestApi.Validators
{
	public class UpdateDriverRequestModelValidator:AbstractValidator<UpdateDriverRequestModel>
	{
		public UpdateDriverRequestModelValidator() 
		{
			RuleFor(x=>x.Id)
				.NotNull().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.EmptyId))
				.NotEmpty().WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidId))
				.GreaterThan(0).WithMessage(ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidId));

		}
	}
}
