using ChurchManager.Application.Commands;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

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

            var usuario = _usuarioRepositorio.FindBy(c => c.Email == command.Email && c.Senha == Domain.Helpers.PasswordHelper.EncodePassword(command.Senha)).FirstOrDefault();
            _messageProducer.SendMessage(command, "topicProducer", "user.login");

            if (usuario != null)
                return Ok(new TokenService().GerarECDsaAssymetric(usuario));

            return BadRequest("Usuário ou senha inválidos");
        }
    }
}
