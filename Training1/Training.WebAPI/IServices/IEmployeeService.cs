using Training.Domain.Entities;
using Training.WebAPI.Models;

namespace Training.WebAPI.IServices
{
    public interface IEmployeeService
    {
       List<Employees> GetAllEmployees();

        bool AddEmployee(EmployeeModel employeeModel);
        string UpdateEmployee(int employeeId, EmployeeModel employeeModel);
        string DeleteEmployee(int employeeId);
    }
}
