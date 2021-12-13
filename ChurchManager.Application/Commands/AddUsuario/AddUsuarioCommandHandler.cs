using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchManager.Application.Commands
{
    public sealed class AddUsuarioCommandHandler : IRequestHandler<AddUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public AddUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio) => (_usuarioRepositorio) = (usuarioRepositorio);

        public Task<Unit> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            var jaExisteUsuarioComEmailInformado = _usuarioRepositorio.FindBy(c => c.Email == request.Email);
            if (jaExisteUsuarioComEmailInformado != null && jaExisteUsuarioComEmailInformado.Any())
                throw new Exception("E-mail informado já cadastrado");

            Usuario usuario = new(request.Email, request.Senha);

            _usuarioRepositorio.Add(usuario);
            _usuarioRepositorio.Save();

            return Task.FromResult(Unit.Value);
        }
    }
}
