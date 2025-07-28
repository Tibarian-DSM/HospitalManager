using HospitalManager.API.Mappers;
using HospitalManager.API.Models;
using HospitalManager.API.Models.Dtos;
using HospitalManager.BLL.Interfaces;
using HospitalManager.BLL.Services;
using HospitalManager.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMedicService _medicService;

        public MedicController(IMedicService medicicService)
        {
            _medicService = medicicService;
        }

        [HttpPost(nameof(AddNewMedic))]
        public IActionResult AddNewMedic(MedicForm form)
        {
            try
            {
            
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _medicService.addNewMedic(form.MApiToBll());

                return Ok(new { message = "Medecin enregistré avec succès !" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("getMedicDetails/{id}")]
        public IActionResult GetMedic(int id)
        {
            try
            {
                Models.Medic medic = _medicService.GetMedicDetails(id).MBllToApi();

                return Ok(medic);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getMedicsByService/{id}")]
        public IActionResult GetMedicByService(int id)
        {
            List<Models.MedicLow> medics = new List<Models.MedicLow>();
            try
            {
                if (_medicService.GetMedicsByService(id) != null || _medicService.GetMedicsByService(id).Count > 0)
                {
                    foreach (BLL.Models.MedicLow medic in _medicService.GetMedicsByService(id))
                    {
                        medics.Add(medic.MLBLLToAPI());
                    } 
                    
                    return Ok(medics);
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
