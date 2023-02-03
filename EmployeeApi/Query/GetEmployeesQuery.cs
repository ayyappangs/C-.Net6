using EmployeeApi.Model;
using MediatR;

namespace EmployeeApi.Query
{
    public record GetEmployeesQuery :IRequest<List<Employee>>;
   
}
