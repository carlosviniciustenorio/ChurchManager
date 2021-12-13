using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Queries.GetMembros
{
    public class GetMembrosQueryHandler : IRequestHandler<GetMembrosQuery, List<MembroViewModel>>
    {
        private readonly IMembroRepositorio _membroRepositorio;
        public GetMembrosQueryHandler(IMembroRepositorio membroRepositorio) => (_membroRepositorio) = (membroRepositorio);

        public Task<List<MembroViewModel>> Handle(GetMembrosQuery request, CancellationToken cancellationToken)
        {
            var list = new List<MembroViewModel>();
            var listOfMembers = _membroRepositorio.FindAll();
            
            foreach (var membro in listOfMembers)
            {
                list.Add(new MembroViewModel(membro));
            }

            return Task.FromResult(list);
        }
    }
}