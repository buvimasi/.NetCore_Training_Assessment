using Microsoft.AspNetCore.Mvc;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get All Employess Information
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Employees()
        {
            var employeeList =  _employeeService.GetAllEmployees();
            return new OkObjectResult(employeeList);

        }

        /// <summary>
        /// Add the Employee Information
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Employees(EmployeeModel employeeModel)
        {
            try
            {
                var employeeAdd = _employeeService.AddEmployee(employeeModel);
                return new OkObjectResult(employeeAdd);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }

        }

        /// <summary>
        /// Edit the Employee Information
        /// </summary>
        /// <returns></returns>

        [HttpPut, Route("{employeeId}")]
        public ActionResult Employees(int employeeId, EmployeeModel employeeModel)
        {
            try
            {
                var employeeUpdate = _employeeService.UpdateEmployee(employeeId, employeeModel);
                return new OkObjectResult(employeeUpdate);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
 

        }

        /// <summary>
        /// Delete the Employee Information
        /// </summary>
        /// <returns></returns>

        [HttpDelete, Route("{employeeId}")]
        public ActionResult Employees(int employeeId)
        {
            try
            {
                var employeeUpdate = _employeeService.DeleteEmployee(employeeId);
                return new OkObjectResult(employeeUpdate);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }


        }

    }
}
