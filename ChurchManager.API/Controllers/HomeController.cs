using ChurchManager.Application.Commands;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Domain.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Setting _appSettings;
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public HomeController(ILogger<HomeController> logger, 
                              IOptions<Setting> appSettings, 
                              IUsuarioRepositorio usuarioRepositorio)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        [Route("Acesso")]
        public async Task<IActionResult> Home([FromBody] AddUsuarioCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var hashSenha = Domain.Helpers.PasswordHelper.EncodePassword(command.Senha);
            var usuario = _usuarioRepositorio.FindBy(c => c.Email == command.Email && c.Senha == hashSenha).FirstOrDefault();

            if (usuario != null)
                return Ok(await GerarJwt(usuario));

            return BadRequest("Usuário ou senha inválidos");
        }

        #region Métodos Privados
        [NonAction]
        private async Task<string> GerarJwt(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        #endregion
    }
}
