using FluentValidation;

namespace EmployeeTaskService.Application.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El id es obligatorio.");

            RuleFor(x => x.Legajo)
                .NotEmpty().WithMessage("El legajo es obligatorio.")
                .MaximumLength(20).WithMessage("El legajo no puede superar los 20 caracteres.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no puede superar los 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("El email no tiene un formato válido.")
                .MaximumLength(150).WithMessage("El email no puede superar los 150 caracteres.");

            RuleFor(x => x.TeamId)
                .NotEmpty().WithMessage("El equipo es obligatorio.");
        }
    }
}