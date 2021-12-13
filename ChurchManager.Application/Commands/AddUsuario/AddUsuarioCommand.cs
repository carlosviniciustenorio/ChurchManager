using FluentValidation;
using MediatR;

namespace ChurchManager.Application.Commands
{
    public sealed record AddUsuarioCommand(string Nome, string Email, string Senha) : IRequest<Unit>;

    public sealed class Validator : AbstractValidator<AddUsuarioCommand>
    {
        public Validator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Informe o nome completo");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Informe o e-mail");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Informe a senha");
        }
    }
}
