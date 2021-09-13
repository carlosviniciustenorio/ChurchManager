using ChurchManager.Application.Queries.GetMembros;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands
{
    public sealed class UpdateMembroHandler : IRequestHandler<UpdateMembroCommand.Command, MembroViewModel>
    {
        private readonly IMembroService _membroService;
        private readonly IMembroRepositorio _membroRepositorio;

        public UpdateMembroHandler(IMembroService membroService, IMembroRepositorio membroRepositorio)
        {
            _membroService = membroService;
            _membroRepositorio = membroRepositorio;
        }

        public Task<MembroViewModel> Handle(UpdateMembroCommand.Command request, CancellationToken cancellationToken)
        {
            var membro = _membroRepositorio.FindById(request.Id);
            if (membro is null) throw new InvalidOperationException("O membro informado não foi localizado.");
                
            var membroAtual = new Membro(request.Nome, request.DataDeNascimento, request.Sexo, request.RG, request.CPF, request.NomePai, request.NomeMae, request.EstadoCivil,
                request.DataDeCasamento, request.NomeConjuge, request.DataDeNascimentoConjuge, request.Endereco, request.Email,
                request.Telefone, request.Celular, request.DataDoBatismo, request.IgrejaAnterior, membro.IgrejaId, request.NomeDoPastorAnterior,
                request.Funcao, request.Status, request.Foto
                );

            membro.AtualizarMembro(membroAtual);

            _membroRepositorio.Edit(membro);
            _membroRepositorio.Save();

            return Task.FromResult(new MembroViewModel(membro));
        }

    }
}
