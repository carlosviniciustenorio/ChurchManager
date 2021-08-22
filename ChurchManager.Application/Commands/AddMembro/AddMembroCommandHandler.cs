using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands.AddMembro
{
    public class AddMembroCommandHandler : IRequestHandler<AddMembroCommand.Command>
    {
        private readonly IMembroRepositorio _membroRepositorio;
        public AddMembroCommandHandler(IMembroRepositorio membroRepositorio)
        {
            _membroRepositorio = membroRepositorio;
        }

        public Task<Unit> Handle(AddMembroCommand.Command command, CancellationToken cancellationToken)
        {
            var membro = new Membro(command.Nome, command.DataDeNascimento, command.Sexo, command.RG, command.CPF,
                command.NomePai, command.NomeMae, command.EstadoCivil, command.DataDeCasamento, command.NomeConjuge,
                command.DataDeNascimentoConjuge, command.Endereco, command.Email, command.Telefone, command.Celular, command.DataDoBatismo,
                command.IgrejaAnterior, command.IdIgreja, command.NomeDoPastorAnterior, command.Funcao, command.Status, command.Foto);

            if(_membroRepositorio != null) _membroRepositorio.Add(membro);

            return Task.FromResult(Unit.Value);
        }
    }
}
