using EmployeeApi.Model;

namespace EmployeeApi.Validations
{
    public interface IEmployeeValidator
    {
        bool IsValidEmployee(Employee employee);
    }
}
