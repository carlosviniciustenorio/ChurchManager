using ChurchManager.Application.Commands.AddIgreja;
using ChurchManager.Application.Queries.GetIgrejas;
using ChurchManager.Application.Servicos;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChurchManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IgrejaController : ControllerBase
    {
        #region Campos
        private readonly IMediator _mediator;
        IUnitOfWork _unitOfWork;
        IIgrejaService _igrejaService;
        #endregion

        #region Construtores
        public IgrejaController(IUnitOfWork unitOfWork, IMediator mediator, IIgrejaService igrejaService)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _igrejaService = igrejaService;
        }
        #endregion

        #region GET
        
        [HttpGet]
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
        public async Task<IActionResult> Igreja(IgrejaInputModel obj)
        {
            try
            {
                var cnpjExiste = _igrejaService.CnpjJaFoiCadastrado(obj.Cnpj, _unitOfWork);
                if (cnpjExiste) return BadRequest();

                var matrizJaFoiCadastrada = obj.Matriz == true ? _igrejaService.MatrizJaFoiCadastrada(_unitOfWork) : false;
                if (matrizJaFoiCadastrada) return BadRequest();

                var igrejaCommand = new AddIgrejaCommand(obj);
                var result = await _mediator.Send(igrejaCommand);

                _unitOfWork.Save();
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
                var igreja = _unitOfWork.RepositorioIgreja.FindById(id);
                if (igreja == null) return BadRequest();

                var cnpjExiste = _igrejaService.CnpjJaFoiCadastrado(obj.Cnpj, _unitOfWork);
                if (cnpjExiste) return BadRequest();

                var matrizJaFoiCadastrada = obj.Matriz == true ? _igrejaService.MatrizJaFoiCadastrada(_unitOfWork) : false;
                if (matrizJaFoiCadastrada) return BadRequest();

                igreja.EditarIgreja(obj.Cnpj, obj.Nome, obj.RazaoSocial, obj.Endereco, obj.Cep, obj.DirigenteId, obj.Ativa, obj.Matriz);

                _unitOfWork.RepositorioIgreja.Edit(igreja);
                _unitOfWork.Save();
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
                var igreja = _unitOfWork.RepositorioIgreja.FindById(id);
                if (igreja == null) return BadRequest();

                _unitOfWork.RepositorioIgreja.Remove(igreja);
                _unitOfWork.Save();
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
