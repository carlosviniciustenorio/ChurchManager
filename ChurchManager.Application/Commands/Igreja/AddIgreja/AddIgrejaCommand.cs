using FluentValidation;
using MediatR;

namespace ChurchManager.Application.Commands
{
    public static class AddIgrejaCommand 
    {
        public record Command(string Cnpj,
                        string Nome,
                        string RazaoSocial,
                        bool Ativa,
                        bool Matriz,
                        string Endereco,
                        string Cep,
                        int DirigenteId) : IRequest<Unit>;

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
