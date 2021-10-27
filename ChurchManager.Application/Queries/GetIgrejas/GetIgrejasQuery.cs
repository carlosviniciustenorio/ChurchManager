using MediatR;
using System.Collections.Generic;

namespace ChurchManager.Application.Queries
{
    public sealed record GetIgrejasQuery : IRequest<List<IgrejaViewModel>>;
}