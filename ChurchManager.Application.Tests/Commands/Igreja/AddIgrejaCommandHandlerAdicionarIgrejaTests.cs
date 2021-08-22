using AutoFixture;
using ChurchManager.Application.Commands.AddIgreja;
using ChurchManager.Domain.Interfaces.Repositorios;
using Moq;
using System.Threading;
using Xunit;

namespace ChurchManager.Application.Tests.Commands
{
    public class AddIgrejaCommandHandlerAdicionarIgrejaTests
    {
        [Fact]
        public void CommandHandler_AdicionandoIgrejaValida_RetornarIdIgrejaCriada()
        {
            //Arrange
            var fixture = new Fixture();
            var igrejaCommand = fixture.Create<AddIgrejaCommand.Command>();

            var igrejaRepositorio = new Mock<IIgrejaRepositorio>();
            var cancelationToken = new CancellationToken();

            //Act
            var addIgrejaCommandHandler = new AddIgrejaCommandHandler(igrejaRepositorio.Object);
            var igreja = addIgrejaCommandHandler.Handle(igrejaCommand, cancelationToken);

            //Assert
            Assert.True(igreja.Id > 0);
        }
    }
}
