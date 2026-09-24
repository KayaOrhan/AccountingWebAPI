using FluentValidation;

namespace Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFCommandValidator : AbstractValidator<CreateUCAFCommand>
    {
        public CreateUCAFCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("UCAF code is required.")
                .MaximumLength(50).WithMessage("UCAF code cannot exceed 50 characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("UCAF name is required.")
                .MaximumLength(100).WithMessage("UCAF name cannot exceed 100 characters.");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("UCAF type is required.")
                .IsInEnum().WithMessage("Invalid UCAF type.");
        }
    }
}
