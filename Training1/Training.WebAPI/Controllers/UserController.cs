using Microsoft.AspNetCore.Mvc;
using Training.WebAPI.Helpers;
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
        /// Authenticate method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


        /// <summary>
        /// Get User List
        /// </summary>
        /// <returns></returns>
        [Authorize]
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
