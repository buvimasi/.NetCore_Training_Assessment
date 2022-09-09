using Microsoft.AspNetCore.Mvc;
using Training.WebAPI.IServices;
using Training.WebAPI.Models;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get User List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var userlist = _userService.GetUser();

                return new OkObjectResult(userlist);
            }
            catch (Exception ex)

            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Update the user information
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateUser(UserModel userModel)
        {
            try
            {
                var userUpdate = _userService.UpdateUser(userModel);
                return new OkObjectResult(userUpdate);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
