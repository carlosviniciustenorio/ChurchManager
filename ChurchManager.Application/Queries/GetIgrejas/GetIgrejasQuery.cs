using MediatR;
using System.Collections.Generic;

namespace ChurchManager.Application.Queries.GetIgrejas
{
    public sealed record GetIgrejasQuery : IRequest<List<IgrejaViewModel>>;
}