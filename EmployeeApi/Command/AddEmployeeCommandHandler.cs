using EmployeeApi.Model;
using EmployeeApi.Repositories;
using MediatR;

namespace EmployeeApi.Command
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository employeeRepository;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepository.SaveEmployee(request.EmployeeId, request.FirstName, request.LastName));
        }
    }
}
