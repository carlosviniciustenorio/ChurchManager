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

        public HomeController(
                              ILogger<HomeController> logger,
                              IOptions<Setting> appSettings, 
                              IUsuarioRepositorio usuarioRepositorio)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        [Route("Acesso")]
        public async Task<IActionResult> Home([FromBody] AddUsuarioCommand request)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            Usuario usuario = new(request.Nome, request.Email, request.Senha);
            var result = _usuarioRepositorio.FindBy(c => c.Email == usuario.Email && c.Senha == usuario.Senha);

            if (result != null)
            {
                //var token = await GerarJwt(usuario);
                return Ok();
            }

            return BadRequest("Usuário ou senha inválidos");
        }
    }
}
