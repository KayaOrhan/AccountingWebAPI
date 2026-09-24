

using FluentValidation;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Role ID is required.")
                .MaximumLength(50).WithMessage("Role ID cannot exceed 50 characters.");
        }
    }
}
