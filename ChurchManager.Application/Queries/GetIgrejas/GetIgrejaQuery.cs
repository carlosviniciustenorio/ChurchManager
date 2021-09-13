using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Application.Queries.GetIgrejas
{
    public sealed record GetIgrejaQuery(int Id) : IRequest<IgrejaViewModel>;
}
