using MediatR;
using System.Collections.Generic;

namespace ChurchManager.Application.Queries.GetIgrejas
{
    public class GetIgrejasQuery : IRequest<List<IgrejaViewModel>>
    {
    }
}