using EmployeeTaskService.Domain.Entities;
using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Commands.Employees.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITeamRepository _teamRepository;

        public CreateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            ITeamRepository teamRepository)
        {
            _employeeRepository = employeeRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var legajo = request.Legajo.Trim();
            var firstName = request.FirstName.Trim();
            var lastName = request.LastName.Trim();
            var email = request.Email.Trim().ToLower();

            var existsLegajo = await _employeeRepository.ExistsByLegajoAsync(legajo, cancellationToken);
            if (existsLegajo)
                throw new InvalidOperationException("Ya existe un empleado con ese legajo.");

            var existsEmail = await _employeeRepository.ExistsByEmailAsync(email, cancellationToken);
            if (existsEmail)
                throw new InvalidOperationException("Ya existe un empleado con ese email.");

            var team = await _teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
            if (team == null)
                throw new InvalidOperationException("El equipo indicado no existe.");

            if (!team.Active)
                throw new InvalidOperationException("No se puede crear un empleado en un equipo inactivo.");

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Legajo = legajo,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                FechaIngreso = request.FechaIngreso,
                Active = true,
                TeamId = request.TeamId
            };

            await _employeeRepository.AddAsync(employee, cancellationToken);
            await _employeeRepository.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}