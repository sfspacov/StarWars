using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StarWars.Application.Test
{
    public class rebeldeTests
    {
        #region Public Methods

        [Fact]
        public void RebeldeApplication_RetornarTodos_Ok()
        {
            // Arrange
            var notificator = new Mock<INotificator>();
            var rebeldeRepository = new Mock<IRebeldeRepository>();
            var itemApplication = new Mock<IItemApplication>();
            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object, itemApplication.Object);

            var rebeldesFakeList = new List<Rebelde>
            {
                NovoRebelde()
            };
            rebeldeRepository.Setup(x => x.RetornarTodos()).Returns(rebeldesFakeList);

            // Act
            var rebeldes = rebeldeApplication.RetornarTodos();

            // Assert
            Assert.True(rebeldes.Any());
        }

        [Fact]
        public void RebeldeApplication_Criar_Ok()
        {
            // Arrange
            var novoRebelde = NovoRebelde();
            var notificator = new Mock<INotificator>();
            var rebeldeRepository = new Mock<IRebeldeRepository>();
            rebeldeRepository.Setup(x => x.Criar(novoRebelde)).Returns(novoRebelde);
            var itemApplication = new Mock<IItemApplication>();
            itemApplication.Setup(x => x.ItensExistem(novoRebelde.Inventario.Itens)).Returns(true);
            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object, itemApplication.Object);


            // Act
            var rebelde = rebeldeApplication.Criar(novoRebelde);

            // Assert
            var expected = 1;

            Assert.Equal(expected, rebelde.Id);
        }

        [Fact]
        public void RebeldeApplication_AtualizarLocalizacao_Ok()
        {
            // Arrange
            var novoRebelde = NovoRebelde();
            novoRebelde.Lozalizacao = new Lozalizacao
            {
                Latitude = 50,
                Longitude = 55,
                NomeDaBase = "Base aérea"
            };
            var notificator = new Mock<INotificator>();
            var rebeldeRepository = new Mock<IRebeldeRepository>();
            rebeldeRepository.Setup(x => x.RetornarPorId(1)).Returns(novoRebelde);
            rebeldeRepository.Setup(x => x.Update(novoRebelde)).Returns(novoRebelde);
            var itemApplication = new Mock<IItemApplication>();
            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object, itemApplication.Object);

            // Act
            var rebelde = rebeldeApplication.AtualizarLocalizacao(novoRebelde);

            // Assert
            var expected = "Base aérea";

            Assert.Equal(expected, rebelde.Lozalizacao.NomeDaBase);
        }

        [Fact]
        public void RebeldeApplication_ReportarTraidor_Ok()
        {
            // Arrange
            var novoRebelde = NovoRebelde();
            novoRebelde.ReporteTraicao = 1;
            var notificator = new Mock<INotificator>();
            var rebeldeRepository = new Mock<IRebeldeRepository>();
            rebeldeRepository.Setup(x => x.RetornarPorId(1)).Returns(novoRebelde);
            rebeldeRepository.Setup(x => x.Update(novoRebelde)).Returns(novoRebelde);
            var itemApplication = new Mock<IItemApplication>();
            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object, itemApplication.Object);

            // Act
            var rebelde = rebeldeApplication.AtualizarLocalizacao(novoRebelde);

            // Assert
            var expected = 1;

            Assert.Equal(expected, rebelde.ReporteTraicao);
        }

        [Fact]
        public void RebeldeApplication_EhTraidor_Ok()
        {
            // Arrange
            var novoRebelde = NovoRebelde();
            novoRebelde.ReporteTraicao = 3;
            var notificator = new Mock<INotificator>();
            var rebeldeRepository = new Mock<IRebeldeRepository>();
            rebeldeRepository.Setup(x => x.RetornarPorId(1)).Returns(novoRebelde);
            rebeldeRepository.Setup(x => x.Update(novoRebelde)).Returns(novoRebelde);
            var itemApplication = new Mock<IItemApplication>();
            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object, itemApplication.Object);

            // Act
            var rebelde = rebeldeApplication.AtualizarLocalizacao(novoRebelde);

            // Assert
            var expected = true;

            Assert.Equal(expected, rebelde.Traidor);
        }

        private static Rebelde NovoRebelde()
        {
            return new Rebelde
            {
                Id = 1,
                Genero = "Q+",
                Idade = 758,
                Inventario = new Inventario
                {
                    Itens = new List<Item>
                    {
                        new Item
                        {
                            Ponto = 4,
                            Nome = "Arma"
                        }
                    }
                },
                Nome = "Monstro",
                Lozalizacao = new Lozalizacao
                {
                    Latitude = 10,
                    Longitude = 20,
                    NomeDaBase = "Andromeda Menor"
                },
            };
        }

        #endregion
    }
}