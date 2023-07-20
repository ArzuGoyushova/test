using FluentValidation;

namespace WebAPI.DTOs.Account
{
    public class LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .NotEmpty().WithMessage("bosh qoyma");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("bosh qoyma");
        }
    }
}
