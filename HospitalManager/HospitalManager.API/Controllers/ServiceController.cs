using HospitalManager.API.Mappers;
using HospitalManager.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        [HttpPost(nameof(AddNewService))]

        public IActionResult AddNewService(string service)
        {
            try
            {
                _servicesService.addNewService(service);
                return Ok(new { message = "Service ajouté avec succès !" });

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(nameof(GetAllServices))]

        public IActionResult GetAllServices()
        {
            List<Models.ServicesMod> services = new List<Models.ServicesMod>();

            try
            {
                if (_servicesService.getAllServices() != null || _servicesService.getAllServices().Count > 0)
                {
                    foreach(BLL.Models.ServicesMod service in _servicesService.getAllServices())
                    {
                        services.Add(service.SBllToApi());

                      
                    }
                    return Ok(services);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveService/{Id}")]
        public IActionResult RemoveService(int Id)
        {
            try
            {
                _servicesService.deleteService(Id);
                return Ok(new { message = "Service supprimé avec succès !" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
