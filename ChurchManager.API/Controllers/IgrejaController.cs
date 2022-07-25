using ChurchManager.Application.Commands;
using ChurchManager.Application.Queries;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchManager.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IgrejaController : ControllerBase
    {
        #region Campos
        private readonly IMediator _mediator;
        IIgrejaService _igrejaService;
        IIgrejaRepositorio _igrejaRepositorio;
        #endregion

        #region Construtores
        public IgrejaController(IIgrejaRepositorio igrejaRepositorio, IMediator mediator, IIgrejaService igrejaService)
        {
            _mediator = mediator;
            _igrejaService = igrejaService;
            _igrejaRepositorio = igrejaRepositorio;
        }
        #endregion

        #region GET

        [HttpGet("Buscar")]
        [ValidateAntiForgeryToken]
        public async Task<List<IgrejaViewModel>> Igreja([FromQuery] GetIgrejasQuery command)
            => await _mediator.Send(command);

        [HttpGet("Buscar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IgrejaViewModel> Igreja([FromQuery] GetIgrejaQuery command)
        => await _mediator.Send(command);

        #endregion

        #region POST
        [HttpPost]
        [Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Igreja([FromBody] AddIgrejaCommand.Command command)
        {
            try
            {
                var cnpjExiste = _igrejaService.CnpjJaFoiCadastrado(command.Cnpj, _igrejaRepositorio);
                if (cnpjExiste)
                    return BadRequest("CNPJ informado já cadastrado");

                var matrizJaFoiCadastrada = command.Matriz == true ? _igrejaService.MatrizJaFoiCadastrada(_igrejaRepositorio) : false;
                if (matrizJaFoiCadastrada) 
                    return BadRequest("Já existe uma Matriz cadastrada");

                var result = await _mediator.Send(command);

                _igrejaRepositorio.Save();
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
        public ActionResult Igreja([FromBody] UpdateIgrejaCommand.Command command)
        {
            try
            {
                var igreja = _mediator.Send(command);
                return Ok(igreja);
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
        public ActionResult Delete([FromBody] int id)
        {
            try
            {
                var igreja = _igrejaRepositorio.FindById(id);
                if (igreja == null) return BadRequest();

                _igrejaRepositorio.Remove(igreja);
                _igrejaRepositorio.Save();
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
