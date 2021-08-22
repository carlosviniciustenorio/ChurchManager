using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Queries.GetIgrejas
{
    public class GetIgrejasQueryHandler : IRequestHandler<GetIgrejasQuery, List<IgrejaViewModel>>
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
    }
}