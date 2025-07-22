using HospitalManager.API.Mappers;
using HospitalManager.API.Models;
using HospitalManager.API.Models.Dtos;
using HospitalManager.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientServices _patientServices;

        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        [HttpPost("AddNewPatientFile/{id}")]
        public IActionResult AddNewPatientFile(int id, [FromBody] PatientFileForm form)
        {
            try
            {
                // Vérifie si le modèle de données est valide
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // Appelle le service pour enregistrer l'user
                _patientServices.AddNewPatientFile(form.ApiToBll(id));

                // Retorune une réponse avec succès
                return Ok(new { message = "Utilisateur enregistré avec succès !" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetPatientFile/{id}")]
        public IActionResult GetPatientFile(int id)
        {
            try
            {
                BLL.Models.PatientFile? patient = _patientServices.GetPatient(id); 

                return Ok(patient);

                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
