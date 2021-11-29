using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands
{
    public class AddIgrejaCommandHandler : IRequestHandler<AddIgrejaCommand.Command, Unit>
    {
        private readonly IIgrejaRepositorio _igrejaRepositorio;
        public AddIgrejaCommandHandler(IIgrejaRepositorio igrejaRepositorio) => (_igrejaRepositorio) = (igrejaRepositorio);

        public Task<Unit> Handle(AddIgrejaCommand.Command request, CancellationToken cancellationToken)
        {
            //var enderecoExistente = ViaCepService.GetEndereco(request.Cep, cancellationToken);

            //if (enderecoExistente is null)
            //    return null;
            
            var igreja = new Igreja(request.Cnpj, 
                                    request.Nome, 
                                    request.RazaoSocial, 
                                    request.Endereco, 
                                    request.Cep, 
                                    true, 
                                    request.Matriz);

            igreja.AdicionarDirigente(request.DirigenteId);

            if(_igrejaRepositorio != null) _igrejaRepositorio.Add(igreja);

            return Task.FromResult(Unit.Value);
        }
    }
}
