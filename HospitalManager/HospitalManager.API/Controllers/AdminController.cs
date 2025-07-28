using HospitalManager.DAL.Interfaces;
using HospitalManager.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HospitalManager.API.Models;
using HospitalManager.BLL.Models;
using HospitalManager.API.Mappers;
using HospitalManager.API.Models.Dtos;
using HospitalManager.BLL.Services;

// Controller qui s'occupe de la partie Admin
namespace HospitalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;


        public AdminController(IAdminService service)
        {
            _adminService = service;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll() {
            List<Models.User> users = new List<Models.User>();


                foreach (GotUser user in _adminService.GetAll())
                {
                    users.Add(UserMapper.BllToApi(user));
                }

            if (users.Count() == 0 || User is null)
            {
                return NoContent();
            }

            return Ok(users);

        }

        
    }


}
