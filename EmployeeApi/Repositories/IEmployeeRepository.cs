using EmployeeApi.Model;

namespace EmployeeApi.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee SaveEmployee(int employeeId, string firstName, string LastName);

    }
}
