using HospitalManager.API.Mappers;
using HospitalManager.API.Models.Dtos;
using HospitalManager.API.Token;
using HospitalManager.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _iAuthServices;
        private readonly TokenManager _tokenManager;

        public AuthController(IAuthService iAuthServices, TokenManager tokenManager)
        {
            _iAuthServices = iAuthServices;
            _tokenManager = tokenManager;
        }

        [HttpPost(nameof(Register))]
        public IActionResult Register(AuthRegisterForm form)
        {
            try
            {
                // Vérifie si le modèle de données est valide
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // Appelle le service pour enregistrer l'user
                _iAuthServices.RegisterUser(UserMapper.ApiToBll(form));

                // Retorune une réponse avec succès
                return Ok(new { message = "Utilisateur enregistré avec succès !" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
