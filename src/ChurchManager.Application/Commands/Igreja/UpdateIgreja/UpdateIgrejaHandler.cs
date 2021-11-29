using ChurchManager.Application.Queries;
using ChurchManager.Application.Servicos;
using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands
{
    public sealed class UpdateIgrejaHandler : IRequestHandler<UpdateIgrejaCommand.Command, IgrejaViewModel>
    {
        private readonly IIgrejaService _igrejaService;
        private readonly IIgrejaRepositorio _igrejaRepositorio;

        public UpdateIgrejaHandler(IIgrejaService igrejaService, IIgrejaRepositorio igrejaRepositorio)
        {
            _igrejaService = igrejaService;
            _igrejaRepositorio = igrejaRepositorio;
        }

        public Task<IgrejaViewModel> Handle(UpdateIgrejaCommand.Command request, CancellationToken cancellationToken)
        {
            var igreja = _igrejaRepositorio.FindById(request.Id);
            if (igreja == null) throw new InvalidOperationException("Igreja informada não localizada.");

            var cnpjExiste = _igrejaService.CnpjJaFoiCadastrado(request.Cnpj, _igrejaRepositorio);
            if (cnpjExiste) throw new InvalidOperationException("CNPJ informado já foi cadastrado.");

            var matrizJaFoiCadastrada = request.Matriz == true ? _igrejaService.MatrizJaFoiCadastrada(_igrejaRepositorio) : false;
            if (matrizJaFoiCadastrada) throw new InvalidOperationException("Já existe uma Igreja Matriz cadastrada.");

            igreja.EditarIgreja(request.Cnpj, 
                                request.Nome,
                                request.RazaoSocial,
                                request.Endereco, 
                                request.Cep, 
                                request.DirigenteId, 
                                request.Ativa,
                                request.Matriz);

            _igrejaRepositorio.Edit(igreja);
            _igrejaRepositorio.Save();

            var updated = new IgrejaViewModel(igreja, null);

            return Task.FromResult(updated);
        }
    }
}
