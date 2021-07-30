using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Queries.GetMembros
{
    public class GetMembrosQueryHandler : IRequestHandler<GetMembrosQuery, List<MembroViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMembrosQueryHandler(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);

        public Task<List<MembroViewModel>> Handle(GetMembrosQuery request, CancellationToken cancellationToken)
        {
            var list = new List<MembroViewModel>();

            foreach (var membro in _unitOfWork.RepositorioMembro.FindAll())
            {
                list.Add(new MembroViewModel(membro));
            }

            return Task.FromResult(list);
        }
    }
}