using Microsoft.IdentityModel.Tokens;
using System.Buffers.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalManager.API.Token
{
    public class TokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenManager(IConfiguration configuration)
        {
            // Récupération des paramètres JWT depuis le fichier de configuration
            _configuration = configuration;
            _secret = _configuration["jwt:key"];
            _issuer = _configuration["jwt:issuer"];
            _audience = _configuration["jwt:audience"];
        }

        public string GenerateJwt(dynamic user, int expirationDate = 1)
        {
            // Création de la clé de sécurité à partir de la clé secrète
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            // Création des identifiants de signature avec l’algorithme HMAC-SHA512
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            DateTime now = DateTime.Now;

            // Création des "claims" (informations contenues dans le token)
            Claim[] myclaims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.LastName ?? "NomInconnu"),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Expiration, now.AddHours(expirationDate).ToString(), ClaimValueTypes.DateTime)
            };

            // Creation du JWT
            JwtSecurityToken token = new JwtSecurityToken(
                claims: myclaims,
                expires: now.AddHours(expirationDate),
                signingCredentials: credentials,
                audience: _audience,
                issuer: _issuer
            );

            // Utilitaire pour écrire le token sous forme de string(base64)
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
