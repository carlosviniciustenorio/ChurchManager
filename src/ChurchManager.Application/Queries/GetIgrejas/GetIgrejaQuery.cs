using MediatR;

namespace ChurchManager.Application.Queries
{
    public sealed record GetIgrejaQuery(int Id) : IRequest<IgrejaViewModel>;
}
