using ChurchManager.Application.Commands;
using ChurchManager.Application.Commands.AddMembro;
using ChurchManager.Application.Queries.GetMembros;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace ChurchManager.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        #region Campos
        private readonly IMediator _mediator;
        IMembroRepositorio _membroRepositorio;
        IMembroService _membroService;
        #endregion

        #region Construtor
        public MembroController(IMembroRepositorio membroRepositorio, IMembroService membroService, IMediator mediator)
        {
            _membroRepositorio = membroRepositorio;
            _membroService = membroService;
            _mediator = mediator;
        }
        #endregion

        #region GET

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var membrosQuery = new GetMembrosQuery();
            var result = await _mediator.Send(membrosQuery);

            return Ok(result);
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Membro([FromBody]AddMembroCommand.Command command)
        {
            try
            {
                var cpfJaFoiCadastrado = _membroService.ValidarSeCPFDoMembroJaFoiCadastrado(command.CPF);
                if (cpfJaFoiCadastrado) return BadRequest();

                var result = await _mediator.Send(command);

                _membroRepositorio.Save();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region EDIT
        
        [HttpPatch]
        [Route("Editar")]
        [ValidateAntiForgeryToken]
        public ActionResult Membro([FromBody] UpdateMembroCommand.Command command)
        {
            try
            {
                var membro = _mediator.Send(command);
                return Ok(membro);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region DELETE
        
        [HttpDelete]
        [Route("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult Membro([FromBody] int id)
        {
            try
            {
                var membro = _membroRepositorio.FindById(id);
                if (membro != null)
                {
                    _membroRepositorio.Remove(membro);
                    _membroRepositorio.Save();
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
