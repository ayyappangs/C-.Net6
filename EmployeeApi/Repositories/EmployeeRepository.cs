using EmployeeApi.Model;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {        
        private readonly IMemoryCache memoryCache;

        public EmployeeRepository(IMemoryCache memoryCache)
        {           
            this.memoryCache = memoryCache;           
        }


        public List<Employee> GetEmployees()
        {
            var employees = (List<Employee>)memoryCache.Get("Employee");
            return employees;
        }

        public Employee SaveEmployee(int employeeId, string firstName, string LastName)
        {
            var employee = new Employee() { EmployeeId = employeeId, FirstName = firstName, LastName = LastName };

            AddEmployeeToCache(employee);

            return employee;
        }

        private void AddEmployeeToCache(Employee employee)
        {
            if (memoryCache.TryGetValue("Employee", out List<Employee> employees))
            {
                employees.Add(employee);
            }
            else
            {
                employees = new List<Employee>() { employee };
            }

            memoryCache.Set("Employee", employees, TimeSpan.FromDays(1));
        }
    }
}
