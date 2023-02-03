using EmployeeApi.Model;
using MediatR;

namespace EmployeeApi.Command
{
    public record AddEmployeeCommand(int EmployeeId, string FirstName, string LastName) : IRequest<Employee>;
    
}
