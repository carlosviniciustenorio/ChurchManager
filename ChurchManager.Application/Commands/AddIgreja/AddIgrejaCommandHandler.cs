using ChurchManager.Domain.Entidades;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands.AddIgreja
{
    public class AddIgrejaCommandHandler : IRequestHandler<AddIgrejaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddIgrejaCommandHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

        public Task<Unit> Handle(AddIgrejaCommand request, CancellationToken cancellationToken)
        {
            var igreja = new Igreja(request.Cnpj, request.Nome, request.RazaoSocial, request.Endereco, request.Cep, true, request.Matriz);
            igreja.AdicionarDirigente(request.DirigenteId);
            _unitOfWork.RepositorioIgreja.Add(igreja);

            return Task.FromResult(Unit.Value);
        }
    }
}
