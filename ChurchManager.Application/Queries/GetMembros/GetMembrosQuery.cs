using MediatR;
using System.Collections.Generic;

namespace ChurchManager.Application.Queries.GetMembros
{
    public class GetMembrosQuery : IRequest<List<MembroViewModel>>
    {
    }
}