using AutoFixture;
using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Enums;
using System;
using Xunit;

namespace ChurchManager.Domain.Tests.Enums
{
    public class EstadoCivilTests
    {
        [Fact]
        public void EstadoCivilSolteiroEstaCorreto()
        {
            //Arrange
            var fixture = new Fixture();
            var membro = fixture.Create<Membro>();

            //Act
            membro.AlterarEstadoCivil(EstadoCivil.Solteiro);

            //Assert
            Assert.True(membro.EstadoCivil == EstadoCivil.Solteiro);
            Assert.True(Convert.ToInt32(membro.EstadoCivil) == 0);
        }

        [Fact]
        public void EstadoCivilCasadoEstaCorreto()
        {
            //Arrange
            var fixture = new Fixture();
            var membro = fixture.Create<Membro>();

            //Act
            membro.AlterarEstadoCivil(EstadoCivil.Casado);

            //Assert
            Assert.True(membro.EstadoCivil == EstadoCivil.Casado);
            Assert.True(Convert.ToInt32(membro.EstadoCivil) == 1);
        }

        [Fact]
        public void EstadoCivilDivorciadoEstaCorreto()
        {
            //Arrange
            var fixture = new Fixture();
            var membro = fixture.Create<Membro>();

            //Act
            membro.AlterarEstadoCivil(EstadoCivil.Divorciado);

            //Assert
            Assert.True(membro.EstadoCivil == EstadoCivil.Divorciado);
            Assert.True(Convert.ToInt32(membro.EstadoCivil) == 2);
        }

        [Fact]
        public void EstadoCivilViuvoEstaCorreto()
        {
            //Arrange
            var fixture = new Fixture();
            var membro = fixture.Create<Membro>();

            //Act
            membro.AlterarEstadoCivil(EstadoCivil.Viuvo);

            //Assert
            Assert.True(membro.EstadoCivil == EstadoCivil.Viuvo);
            Assert.True(Convert.ToInt32(membro.EstadoCivil) == 3);
        }
    }
}
