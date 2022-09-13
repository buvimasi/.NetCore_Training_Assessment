using Microsoft.AspNetCore.Mvc;
using Training.WebAPI.Helpers;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        /// Get the Employee info by Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet,Route("{employeeId}")]
        public ActionResult Employees(int employeeId)
        {
            var employeeList = _employeeService.GetEmployee(employeeId);
            return new OkObjectResult(employeeList);

        }

        /// <summary>
        /// Add the Employee Information
        /// </summary>
        /// <param name="employeeModel"></param>
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
        /// Update the Employee information
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employeeModel"></param>
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
        /// <param name="employeeId"></param>
        /// <returns></returns>

        [HttpDelete, Route("Delete/{employeeId}")]
        public ActionResult EmployeesDelete(int employeeId)
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
