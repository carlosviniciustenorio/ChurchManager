using ChurchManager.Application.Queries;
using FluentValidation;
using MediatR;

namespace ChurchManager.Application.Commands
{
    public static class UpdateIgrejaCommand
    {
        public sealed record Command(int Id, 
                                    string Cnpj,
                                    string Nome,
                                    string RazaoSocial,
                                    bool Ativa,
                                    bool Matriz,
                                    string Endereco,
                                    string Cep,
                                    int DirigenteId) : IRequest<IgrejaViewModel>;

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Cnpj)
                    .NotEmpty().WithMessage("CNPJ não pode ser vazio")
                    .Length(14);
            }
        }
    }
}
