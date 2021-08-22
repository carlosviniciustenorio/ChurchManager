using AutoFixture;
using ChurchManager.Application.Commands.AddMembro;
using ChurchManager.Domain.Interfaces.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChurchManager.Application.Tests.Commands.Membro
{
    public class AddMembroCommandHandlerAdicionarMembroTests
    {
        [Fact]
        public void CommandHandler_AdicionandoMembroValido_RetornarIdMembroCriado()
        {
            //Arrange
            var fixture = new Fixture();
            var membroCommand = fixture.Create<AddMembroCommand.Command>();

            var membroRepositorio = new Mock<IMembroRepositorio>();
            var cancellationToken = new CancellationToken();

            //Act
            var addMembroCommandHandler = new AddMembroCommandHandler(membroRepositorio.Object);
            var igreja = addMembroCommandHandler.Handle(membroCommand, cancellationToken);

            //Equals
            Assert.True(igreja.Id > 0);
        }
    }
}
