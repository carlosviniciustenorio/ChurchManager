using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Queries.GetIgrejas
{
    public class GetIgrejasQueryHandler : IRequestHandler<GetIgrejasQuery, List<IgrejaViewModel>>,
                                          IRequestHandler<GetIgrejaQuery, IgrejaViewModel>
    {
        private readonly IIgrejaRepositorio _igrejaRepositorio;
        public GetIgrejasQueryHandler(IIgrejaRepositorio igrejaRepositorio) => (_igrejaRepositorio) = (igrejaRepositorio);

        public Task<List<IgrejaViewModel>> Handle(GetIgrejasQuery request, CancellationToken cancellationToken)
        {
            var igrejas = new List<IgrejaViewModel>();

            foreach (var igreja in _igrejaRepositorio.FindAll())
            {
                igrejas.Add(new IgrejaViewModel(igreja));
            }

            return Task.FromResult(igrejas);
        }

        public Task<IgrejaViewModel> Handle(GetIgrejaQuery request, CancellationToken cancellationToken)
        {
            var igreja = _igrejaRepositorio.FindById(request.Id);
            if (igreja is null) throw new InvalidOperationException("A igreja informada não foi localizada.");

            return Task.FromResult(new IgrejaViewModel(igreja));
        }
    }
}