﻿using FluentValidation;

namespace Spd3.ViewModels.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
	{
		public RegistrationViewModelValidator()
		{
			RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email cannot be empty");
			RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
			RuleFor(vm => vm.RealName).NotEmpty().WithMessage("RealName cannot be empty");			
		}
	}
}
