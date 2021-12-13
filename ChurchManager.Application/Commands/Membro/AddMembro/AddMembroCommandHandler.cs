using ChurchManager.Application.Queries.GetMembros;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands.AddMembro
{
    public class AddMembroCommandHandler : IRequestHandler<AddMembroCommand.Command, MembroViewModel>
    {
        private readonly IMembroRepositorio _membroRepositorio;
        private readonly IMembroService _membroService;
        public AddMembroCommandHandler(IMembroRepositorio membroRepositorio, IMembroService membroService)
        {
            _membroRepositorio = membroRepositorio;
            _membroService = membroService;
        }

        public Task<MembroViewModel> Handle(AddMembroCommand.Command command, CancellationToken cancellationToken)
        {
            var membro = new Membro(command.Nome, command.DataDeNascimento, command.Sexo, command.RG, command.CPF,
                command.NomePai, command.NomeMae, command.EstadoCivil, command.DataDeCasamento, command.NomeConjuge,
                command.DataDeNascimentoConjuge, command.Endereco, command.Email, command.Telefone, command.Celular, command.DataDoBatismo,
                command.IgrejaAnterior, command.IdIgreja, command.NomeDoPastorAnterior, command.Funcao, command.Status, command.Foto);

            _membroRepositorio.Add(membro);
            _membroRepositorio.Save();

            return Task.FromResult(new MembroViewModel(membro));
        }
    }
}
