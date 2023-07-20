using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebAPI.DTOs.Account
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("bosh qoyma")
                .MaximumLength(20).WithMessage("20den boyuk olmaz");
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("bosh qoyma")
                .MaximumLength(20).WithMessage("20den boyuk olmaz");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("bosh qoyma")
                .MinimumLength(8).WithMessage("8den ashagi olmaz")
                .MaximumLength(20).WithMessage("20den boyuk olmaz");
            RuleFor(x => x.RePassword)
                .NotEmpty().WithMessage("bosh qoyma")
                .MinimumLength(8).WithMessage("8den ashagi olmaz")
                .MaximumLength(20).WithMessage("20den boyuk olmaz");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.RePassword)
                {
                    context.AddFailure("RePassword", "eyni deyil");
                }
            });
        }
    }
}
