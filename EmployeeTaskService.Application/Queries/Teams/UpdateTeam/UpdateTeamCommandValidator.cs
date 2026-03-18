using FluentValidation;

namespace EmployeeTaskService.Application.Commands.Teams.UpdateTeam
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El id del equipo es obligatorio.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("La descripción no puede superar los 250 caracteres.");
        }
    }
}