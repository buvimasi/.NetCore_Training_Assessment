using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SoftLockController : Controller
    {
        private readonly ISoftLockService _softLockService;

        public SoftLockController(ISoftLockService softLockService)
        {
            _softLockService = softLockService;
        }
        /// <summary>
        /// Get List of SoftLock
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSoftLock()
        {
            var softlock = _softLockService.GetSoftLocks();
            return new OkObjectResult(softlock);
        }
        /// <summary>
        /// Get softlock by Id
        /// </summary>
        /// <param name="softlockId"></param>
        /// <returns></returns>
        [HttpGet, Route("{softlock}")]
        public ActionResult GetSoftLockById(int softlockId)
        {
            try
            {
                var softlock = _softLockService.GetSoftLock(softlockId);
                return new OkObjectResult(softlock);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }


        }
        /// <summary>
        /// Get Employee's softlock
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet,Route("Employeesoftlock/{employeeId}")]
        public ActionResult GetSoftLockByEmployeeId(int employeeId)
        {
            try
            {
                var softlock = _softLockService.GetSoftLockByEmployeeId(employeeId);
                return new OkObjectResult(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Add softlock
        /// </summary>
        /// <param name="softLockModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSoftLock(SoftLockModel softLockModel)
        {
            try
            {
                var softlock = _softLockService.AddSoftLock(softLockModel);
                return new OkObjectResult(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Update softlock info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="softLockModel"></param>
        /// <returns></returns>
        [HttpPut,Route("{id}")]
        public ActionResult UpdateSoftLock(int id,SoftLockModel softLockModel)
        {
            try
            {
                var softlock = _softLockService.UpdateSoftLock(id,softLockModel);
                return new OkObjectResult(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// Update softlock info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult DeleteSoftLock(int id)
        {
            try
            {
                var softlock = _softLockService.DeleteSoftLock(id);
                return new OkObjectResult(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
