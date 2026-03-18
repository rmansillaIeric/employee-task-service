using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITeamRepository _teamRepository;

        public UpdateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            ITeamRepository teamRepository)
        {
            _employeeRepository = employeeRepository;
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee == null)
                return false;

            var legajo = request.Legajo.Trim();
            var firstName = request.FirstName.Trim();
            var lastName = request.LastName.Trim();
            var email = request.Email.Trim().ToLower();

            var duplicatedLegajo = await _employeeRepository.ExistsByLegajoAsync(legajo, request.Id, cancellationToken);
            if (duplicatedLegajo)
                throw new InvalidOperationException("Ya existe otro empleado con ese legajo.");

            var duplicatedEmail = await _employeeRepository.ExistsByEmailAsync(email, request.Id, cancellationToken);
            if (duplicatedEmail)
                throw new InvalidOperationException("Ya existe otro empleado con ese email.");

            var team = await _teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
            if (team == null)
                throw new InvalidOperationException("El equipo indicado no existe.");

            if (!team.Active)
                throw new InvalidOperationException("No se puede asignar el empleado a un equipo inactivo.");

            employee.Legajo = legajo;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Email = email;
            employee.FechaIngreso = request.FechaIngreso;
            employee.TeamId = request.TeamId;
            employee.Active = request.Active;

            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            await _employeeRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}