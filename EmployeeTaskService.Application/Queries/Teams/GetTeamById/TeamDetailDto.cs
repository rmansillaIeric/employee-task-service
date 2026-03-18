namespace EmployeeTaskService.Application.Queries.Teams.GetTeamById
{
    public class TeamDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public int ActiveEmployeesCount { get; set; }
    }
}