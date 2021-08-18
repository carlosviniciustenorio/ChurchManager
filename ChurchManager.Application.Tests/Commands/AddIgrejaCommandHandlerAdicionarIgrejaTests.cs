using AutoFixture;
using ChurchManager.Application.Commands.AddIgreja;
using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia.UnitOfWork;
using Moq;
using System.Threading;
using Xunit;

namespace ChurchManager.Application.Tests.Commands
{
    public class AddIgrejaCommandHandlerAdicionarIgrejaTests
    {
        [Fact]
        public void CommandHandler_AdicionandoIgrejaValida_RetornarSuceso()
        {
            //Arrange
            var fixture = new Fixture();
            var igrejaCommand = fixture.Create<AddIgrejaCommand>();

            var unitOfWork = new Mock<IUnitOfWork>();
            var cancelationToken = new CancellationToken();

            //Act
            var addIgrejaCommandHandler = new AddIgrejaCommandHandler(unitOfWork.Object);
            addIgrejaCommandHandler.Handle(igrejaCommand, cancelationToken);

            //Assert
            //Não está sendo possível testar o handler sem uma implementação concreta do repositorio.
            //É necessário melhorar a arquitetura.

        }
    }
}
