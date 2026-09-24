

using FluentValidation;

namespace Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.DatabaseName)
                .NotEmpty().WithMessage("Database name is required.")
                .MaximumLength(100).WithMessage("Database name cannot exceed 100 characters.");

            RuleFor(x => x.ServerName)
                .NotEmpty().WithMessage("Server name is required.")
                .MaximumLength(100).WithMessage("Server name cannot exceed 100 characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");



        }
    }
}
