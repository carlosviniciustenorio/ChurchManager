using AutoFixture;
using ChurchManager.Domain.Entidades;
using Xunit;

namespace ChurchManager.Domain.Tests.IgrejaTest
{
    public class IgrejaTests
    {
        [Fact]
        public void AdicionandoDirigenteNaIgrejaComSucesso()
        {
            //Arrange
            var fixture = new Fixture();
            var igreja = fixture.Create<Igreja>();

            //Act
            igreja.AdicionarDirigente(1);

            //Assert
            Assert.True(igreja.DirigenteId == 1);
        }
    }
}
