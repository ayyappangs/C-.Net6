using EmployeeApi.Model;
using EmployeeApi.Repositories;
using MediatR;

namespace EmployeeApi.Query
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<Employee>>
    {
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeesHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public Task<List<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepository.GetEmployees());
        }
    }

}
