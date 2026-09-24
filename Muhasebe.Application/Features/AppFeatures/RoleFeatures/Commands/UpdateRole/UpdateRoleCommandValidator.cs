using FluentValidation;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Role ID is required.")
                .MaximumLength(50).WithMessage("Role ID cannot exceed 50 characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role name is required.")
                .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Role code is required.")
                .MaximumLength(50).WithMessage("Role code cannot exceed 50 characters.");
        }
    }
}
