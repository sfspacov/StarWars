//using StarWars.Domain.Entities;
//using StarWars.Domain.Interfaces;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;

//namespace StarWars.Application.Test
//{
//    public class rebeldeTests
//    {
//        #region Public Methods

//        [Fact]
//        public void rebelde_GetAll_Any()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);

//            var rebeldesFakeList = new List<Rebelde>
//            {
//                Newrebelde()
//            };
//            rebeldeRepository.Setup(x => x.RetornarTodos()).Returns(rebeldesFakeList);

//            // Act
//            var rebeldes = rebeldeApplication.RetornarTodos();

//            // Assert
//            Assert.True(rebeldes.Any());
//        }

//        [Fact]
//        public void rebelde_GetAll_Empty()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);

//            // Act
//            var rebeldes = rebeldeApplication.RetornarTodos();

//            // Assert
//            Assert.Null(rebeldes);
//        }

//        [Fact]
//        public void rebelde_GetBySku_Any()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var rebeldeFake = Newrebelde();
//            rebeldeRepository.Setup(x => x.RetornarPorId(rebeldeFake.Id)).Returns(rebeldeFake);

//            // Act
//            var rebeldes = rebeldeApplication.RetornarPorId(rebeldeFake.Id);

//            // Assert
//            Assert.False(rebeldes is null);
//        }

//        [Fact]
//        public void rebelde_GetBySku_Empty()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var rebeldeFake = Newrebelde();

//            // Act
//            var rebeldes = rebeldeApplication.RetornarPorId(rebeldeFake.Id);

//            // Assert
//            Assert.True(rebeldes is null);
//        }

//        [Fact]
//        public void rebelde_Create_Existentrebelde()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var errorsCount = 0;
//            var rebeldeFake = Newrebelde();
//            notificator.Setup(x => x.AddError(It.IsAny<string>())).Callback((string msg) =>
//            {
//                errorsCount++;
//            }).Verifiable();
//            rebeldeRepository.Setup(x => x.RetornarPorId(rebeldeFake.Id)).Returns(rebeldeFake);

//            // Act
//            var rebelde = rebeldeApplication.Criar(rebeldeFake);
//            // Assert
//            Assert.Equal(1, errorsCount);
//        }

//        [Fact]
//        public void rebelde_Create_Ok()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);

//            var rebeldeFake = Newrebelde();
//            rebeldeRepository.Setup(x => x.Criar(rebeldeFake)).Returns(rebeldeFake);

//            // Act
//            var rebelde = rebeldeApplication.Criar(rebeldeFake);

//            // Assert
//            Assert.Equal(rebelde, rebeldeFake);
//        }

//        [Fact]
//        public void rebelde_Create_Null()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var rebeldeFake = Newrebelde();

//            // Act
//            var rebelde = rebeldeApplication.Criar(rebeldeFake);

//            // Assert
//            Assert.Null(rebelde);
//        }

//        [Fact]
//        public void rebelde_Update_Ok()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var rebeldeFake1 = Newrebelde();
//            var rebeldeFake2 = rebeldeFake1;
//            rebeldeFake2.NomeDaBase = "Shampoo B";
//            rebeldeRepository.Setup(x => x.AtualizarLocalizacao(rebeldeFake2)).Returns(rebeldeFake2);

//            // Act
//            var rebelde = rebeldeApplication.AtualizarLocalizacao(rebeldeFake2);

//            // Assert
//            Assert.Equal(rebelde, rebeldeFake2);
//        }

//        [Fact]
//        public void rebelde_Update_Null()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var rebeldeFake1 = Newrebelde();
//            var rebeldeFake2 = rebeldeFake1;
//            rebeldeFake2.NomeDaBase = "Shampoo B";

//            // Act
//            var rebelde = rebeldeApplication.AtualizarLocalizacao(rebeldeFake2);

//            // Assert
//            Assert.Null(rebelde);
//        }

//        [Fact]
//        public void rebelde_Delete_Ok()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var rebeldeFake = Newrebelde();
//            rebeldeRepository.Setup(x => x.ReportarTraidor(rebeldeFake.Id)).Returns(true);

//            // Act
//            var rebeldeResponse = rebeldeApplication.ReportarTraidor(rebeldeFake.Id);

//            // Assert
//            Assert.True(rebeldeResponse);
//        }

//        [Fact]
//        public void rebelde_Delete_False()
//        {
//            // Arrange
//            var notificator = new Mock<INotificator>();
//            var rebeldeRepository = new Mock<IRebeldeRepository>();
//            var rebeldeApplication = new RebeldeApplication(notificator.Object, rebeldeRepository.Object);
//            var rebeldeFake = Newrebelde();
//            rebeldeRepository.Setup(x => x.ReportarTraidor(rebeldeFake.Id)).Returns(false);

//            // Act
//            var rebeldeResponse = rebeldeApplication.ReportarTraidor(rebeldeFake.Id);

//            // Assert
//            Assert.False(rebeldeResponse);
//        }

//        #endregion

//        #region Private Methods

//        private static Rebelde Newrebelde()
//        {
//            return new Rebelde
//            {
//                Id = 43264,
//                NomeDaBase = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
//                Inventario = new Inventario
//                {
//                    Itens = new List<Item> {
//                        //new Item{NomeDaBase = "SP", Quantity = 12, Type = "ECOMMERCE"},
//                        //new Item{NomeDaBase = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
//                    }
//                },
//            };
//        }

//        #endregion
//    }
//}