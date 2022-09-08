using Training.Domain.Data;
using Training.Domain.Entities;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Services
{


    public class EmployeeServices : IEmployeeService
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeServices(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddEmployee(EmployeeModel employeeModel)
        {
            if(employeeModel != null)
            {
                _dbContext.Add(new Employees
                {
                    Email = employeeModel.Email,
                    Name = employeeModel.Name,
                    Manager = employeeModel.Manager,
                    Status = employeeModel.Status,
                    LockStatus = employeeModel.LockStatus,
                    Wfm_Manager = employeeModel.Wfm_Manager,
                    Experience = employeeModel.Experience,
                    ProfileId = employeeModel.ProfileId
                });

                _dbContext.SaveChanges();

                return true;
               
            }
            else
            {
                return false;
            }
        }

        public string DeleteEmployee(int employeeId)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if(employee!=null)
            {
                _dbContext.Remove(employee);
                _dbContext.SaveChanges();
                return "Records Deleted successfully";
            }
            else
            {
                return "Records not found";

            }
        }

        public List<Employees> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
           
        }

        public string UpdateEmployee(int employeeId, EmployeeModel employeeModel)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if(employee!=null)
            {
                employee.Status = employeeModel.Status;
                employee.LockStatus = employeeModel.LockStatus;
                employee.Wfm_Manager = employeeModel.Wfm_Manager;
                employee.Experience = employeeModel.Experience;
                employee.ProfileId = employeeModel.ProfileId;
                employee.Name = employeeModel.Name;
                employee.Manager = employeeModel.Manager;

                _dbContext.Update(employee);
                _dbContext.SaveChanges();

                return "Employee Updated Successfully";
            }
            else
            {
                return "Employee record not found ";
            }
        }
    }
}
