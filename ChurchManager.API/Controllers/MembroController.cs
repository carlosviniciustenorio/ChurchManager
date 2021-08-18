using ChurchManager.Application.Commands.AddMembro;
using ChurchManager.Application.Queries.GetMembros;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Entidades;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
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
        IUnitOfWork _unitOfWork;
        IMembroService _membroService;
        #endregion

        #region Construtor
        public MembroController(IUnitOfWork unitOfWork, IMembroService membroService, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
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
        public async Task<IActionResult> Membro(MembroInputModel obj)
        {
            try
            {
                var membro = new AddMembroCommand(obj.Nome, obj.DataDeNascimento, obj.Sexo, obj.RG, obj.CPF, obj.NomePai, obj.NomeMae, obj.EstadoCivil,
                    obj.DataDeCasamento, obj.NomeConjuge, obj.DataDeNascimentoConjuge, obj.Endereco, obj.Email,
                    obj.Telefone, obj.Celular, obj.DataDoBatismo, obj.IgrejaAnterior, obj.IgrejaId, obj.NomeDoPastorAnterior,
                    obj.Funcao, obj.Status, obj.Foto);

                var cpfJaFoiCadastrado = _membroService.ValidarSeCPFDoMembroJaFoiCadastrado(membro.CPF);
                if (cpfJaFoiCadastrado) return BadRequest();

                var result = await _mediator.Send(membro);

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
        public ActionResult Membro(int id, MembroViewModel obj)
        {
            try
            {
                var membro = _unitOfWork.RepositorioMembro.FindById(id);
                var membroAtual = new Membro(obj.Nome, obj.DataDeNascimento, obj.Sexo, obj.RG, obj.CPF, obj.NomePai, obj.NomeMae, obj.EstadoCivil,
                    obj.DataDeCasamento, obj.NomeConjuge, obj.DataDeNascimentoConjuge, obj.Endereco, obj.Email,
                    obj.Telefone, obj.Celular, obj.DataDoBatismo, obj.IgrejaAnterior, membro.IgrejaId, obj.NomeDoPastorAnterior,
                    obj.Funcao, obj.Status, obj.Foto
                    );

                
                if (membro != null)
                {
                    membro.AtualizarMembro(membroAtual);

                    _unitOfWork.RepositorioMembro.Edit(membro);
                    _unitOfWork.Save();
                }

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
        public ActionResult Membro(int id)
        {
            try
            {
                var membro = _unitOfWork.RepositorioMembro.FindById(id);
                if (membro != null)
                {
                    _unitOfWork.RepositorioMembro.Remove(membro);
                    _unitOfWork.Save();
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
