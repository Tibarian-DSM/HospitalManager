using HospitalManager.API.Mappers;
using HospitalManager.API.Models;
using HospitalManager.BLL.Interfaces;
using HospitalManager.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

       [HttpGet("GetUserById/{id}")]
       public IActionResult GetUserById(int id)
        {
            try
            {
                BLL.Models.GotUser user = _userService.getUserById(id);
                Models.User ApiUser = user.BllToApi();
                if (ApiUser != null)
                {

                    return Ok(ApiUser);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUsersByRole/{role}")]
        public IActionResult GetUsersByRole(string role)
        {
            List<Models.User> users = new List<Models.User>();

            try
            {
                foreach (GotUser user in _userService.getUsersByRole(role))
                {
                    users.Add(user.BllToApi());
                }

                if (users.Count() == 0 || User is null)
                {
                    return NoContent();
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
