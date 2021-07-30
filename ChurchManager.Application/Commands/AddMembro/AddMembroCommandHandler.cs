using ChurchManager.Domain.Entidades;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands.AddMembro
{
    public class AddMembroCommandHandler : IRequestHandler<AddMembroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddMembroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(AddMembroCommand request, CancellationToken cancellationToken)
        {
            var membro = new Membro(request.Nome, request.DataDeNascimento, request.Sexo, request.RG, request.CPF,
                request.NomePai, request.NomeMae, request.EstadoCivil, request.DataDeCasamento, request.NomeConjuge,
                request.DataDeNascimentoConjuge, request.Endereco, request.Email, request.Telefone, request.Celular, request.DataDoBatismo,
                request.IgrejaAnterior, request.IgrejaId, request.NomeDoPastorAnterior, request.Funcao, request.Status, request.Foto);

            _unitOfWork.RepositorioMembro.Add(membro);

            return Task.FromResult(Unit.Value);
        }
    }
}
