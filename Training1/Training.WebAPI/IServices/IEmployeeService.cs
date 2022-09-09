using Training.Domain.Entities;
using Training.WebAPI.Models;

namespace Training.WebAPI.IServices
{
    public interface IEmployeeService
    {
       List<Employees> GetAllEmployees();
        Employees GetEmployee(int employeeId);
        bool AddEmployee(EmployeeModel employeeModel);
        string UpdateEmployee(int employeeId, EmployeeModel employeeModel);
        string DeleteEmployee(int employeeId);
    }
}
