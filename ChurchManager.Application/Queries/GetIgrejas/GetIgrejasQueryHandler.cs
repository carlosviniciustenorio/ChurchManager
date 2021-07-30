using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Queries.GetIgrejas
{
    public class GetIgrejasQueryHandler : IRequestHandler<GetIgrejasQuery, List<IgrejaViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetIgrejasQueryHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

        public Task<List<IgrejaViewModel>> Handle(GetIgrejasQuery request, CancellationToken cancellationToken)
        {
            var igrejas = new List<IgrejaViewModel>();

            foreach (var igreja in _unitOfWork.RepositorioIgreja.FindAll())
            {
                igrejas.Add(new IgrejaViewModel(igreja));
            }

            return Task.FromResult(igrejas);
        }
    }
}