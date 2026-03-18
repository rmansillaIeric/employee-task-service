using FluentValidation;

namespace EmployeeTaskService.Application.Commands.Teams.CreateTeam
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del equipo es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("La descripción no puede superar los 250 caracteres.");
        }
    }
}