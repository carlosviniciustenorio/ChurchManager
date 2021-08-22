using ChurchManager.Application.Commands.AddIgreja;
using ChurchManager.Application.Queries.GetIgrejas;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        IUnitOfWork _unitOfWork;
        IIgrejaService _igrejaService;
        IIgrejaRepositorio _igrejaRepositorio;
        #endregion

        #region Construtores
        public IgrejaController(IUnitOfWork unitOfWork, IIgrejaRepositorio igrejaRepositorio, IMediator mediator, IIgrejaService igrejaService)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _igrejaService = igrejaService;
            _igrejaRepositorio = igrejaRepositorio;
        }
        #endregion

        #region GET
        
        [HttpGet]
        [Route("Buscar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Igreja()
        {
            var igrejaQuery = new GetIgrejasQuery();
            var result = await _mediator.Send(igrejaQuery);

            return Ok(result);
        }

        #endregion

        #region POST
        [HttpPost]
        [Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Igreja(AddIgrejaCommand.Command command)
        {
            try
            {
                var cnpjExiste = _igrejaService.CnpjJaFoiCadastrado(command.Cnpj, _igrejaRepositorio);
                if (cnpjExiste) return BadRequest();

                var matrizJaFoiCadastrada = command.Matriz == true ? _igrejaService.MatrizJaFoiCadastrada(_igrejaRepositorio) : false;
                if (matrizJaFoiCadastrada) return BadRequest();

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
        public ActionResult Igreja(int id, IgrejaViewModel obj)
        {
            try
            {
                var igreja = _igrejaRepositorio.FindById(id);
                if (igreja == null) return BadRequest();

                var cnpjExiste = _igrejaService.CnpjJaFoiCadastrado(obj.Cnpj, _igrejaRepositorio);
                if (cnpjExiste) return BadRequest();

                var matrizJaFoiCadastrada = obj.Matriz == true ? _igrejaService.MatrizJaFoiCadastrada(_igrejaRepositorio) : false;
                if (matrizJaFoiCadastrada) return BadRequest();

                igreja.EditarIgreja(obj.Cnpj, obj.Nome, obj.RazaoSocial, obj.Endereco, obj.Cep, obj.DirigenteId, obj.Ativa, obj.Matriz);

                _igrejaRepositorio.Edit(igreja);
                _igrejaRepositorio.Save();
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
        public ActionResult Delete(int id)
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
