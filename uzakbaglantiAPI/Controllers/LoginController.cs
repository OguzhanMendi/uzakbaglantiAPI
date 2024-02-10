using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using uzakbaglantiAPI.Context;
using uzakbaglantiAPI.Model;
using uzakbaglantiAPI.Repositories.Interfaces;

namespace uzakbaglantiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult>Login(LoginModel model)
        {
            // Kullanıcı kimlik bilgilerini kontrol et, örneğin bir veritabanından kontrol edebilirsiniz

            var kul = _loginRepository.kullaniciVarMi(model.ad,model.sifre);

            if (kul!=null)
            {
                var token = GenerateJwtToken(model.ad);
                var response = new
                {
                    ad = model.ad,
                    token = token
                };
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
                // Token üret
              
           
        }


        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ModülYazilim10082002@?56?231198312@@")); // Burada key'i dikkatli saklayın
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenExpiration = DateTime.UtcNow.AddDays(7);
            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: new[] {
                    new Claim(ClaimTypes.Name, username),
                },
                expires: tokenExpiration, // Token'ın geçerlilik süresi
                signingCredentials: credentials
            );

           var tokens =   new JwtSecurityTokenHandler().WriteToken(token);

            return  tokens;
        }
    }
}
