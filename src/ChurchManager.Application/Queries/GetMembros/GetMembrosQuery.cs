using MediatR;
using System.Collections.Generic;

namespace ChurchManager.Application.Queries.GetMembros
{
    public sealed record GetMembrosQuery : IRequest<List<MembroViewModel>>;
}