using ChurchManager.Application.Commands;
using ChurchManager.Application.Servicos;
<<<<<<< HEAD
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Domain.Settings;
using ChurchManager.Infrastructure.RabbitMQ;
=======
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.RabbitMQ;
>>>>>>> test
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sentry;
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
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMessageProducer _messageProducer;

        public HomeController(ILogger<HomeController> logger,
                              IUsuarioRepositorio usuarioRepositorio,
                              IMessageProducer messageProducer)
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        [Route("Acesso")]
        public IActionResult Home([FromBody] AddUsuarioCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            //var hashSenha = Domain.Helpers.PasswordHelper.EncodePassword(command.Senha);
            //var usuario = _usuarioRepositorio.FindBy(c => c.Email == command.Email && c.Senha == hashSenha).FirstOrDefault();
            Usuario user = new(command.Nome, command.Email, command.Senha);
            _messageProducer.SendMessage(command, "topicProducer", "user.created");

            if (user != null)
                return Ok(new TokenService().GerarECDsaAssymetric(user));

            return BadRequest("Usuário ou senha inválidos");
        }
    }
}
