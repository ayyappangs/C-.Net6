using EmployeeApi.Model;

namespace EmployeeApi.Validations
{
    public class EmployeeValidator : IEmployeeValidator
    {
        public bool IsValidEmployee(Employee employee)
        {
            if(employee.EmployeeId <= 0 || string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
            {
                return false;
            }

            return true;
        }
    }
}
