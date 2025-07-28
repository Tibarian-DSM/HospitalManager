using HospitalManager.API.Mappers;
using HospitalManager.API.Models.Dtos;
using HospitalManager.BLL.Interfaces;
using HospitalManager.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// Controleur qui prend en charge tout ce qui est en rapport avec les rendez-vous
namespace HospitalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointementController : ControllerBase
    {
        private readonly IAppointementService _appointementService;

        public AppointementController(IAppointementService appointementService)
        {
            _appointementService = appointementService;
        }
        
        [HttpPost(nameof(createAppointement))]
        public IActionResult createAppointement (AppointementForm form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _appointementService.createAppointement(form.ApApiToBll());

                // Retorune une réponse avec succès
                return Ok(new { message = "Rendez-vous enregistré avec succès !" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("getAppointementById/{id}")]
        public IActionResult getAppointementById(int id)
        {
            try
            {
                Models.Appointement appointement = _appointementService.GetAppointementById(id).ApBllToApi();

                return Ok(appointement);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAppointementsByPatientId/{id}")]
        public IActionResult getAppointementsByPatientId(int id)
        {
            List<Models.Appointement> appointements = new List<Models.Appointement>();
            try
            {
                if(_appointementService.GetAppointementsByPatientId(id)!=null && _appointementService.GetAppointementsByPatientId(id).Count() > 0)
                {
                    foreach(BLL.Models.GotAppointement ap in _appointementService.GetAppointementsByPatientId(id))
                    {
                        appointements.Add(ap.ApBllToApi());
                    }

                    return Ok(appointements);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAppointementsByMedicId/{id}")]
        public IActionResult getAppointementsByMedicId(int id)
        {
            List<Models.Appointement> appointements = new List<Models.Appointement>();
            try
            {
                if (_appointementService.GetAppointementsByMedicId(id) != null && _appointementService.GetAppointementsByMedicId(id).Count() > 0)
                {
                    foreach (BLL.Models.GotAppointement ap in _appointementService.GetAppointementsByMedicId(id))
                    {
                        appointements.Add(ap.ApBllToApi());
                    }

                    return Ok(appointements);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
