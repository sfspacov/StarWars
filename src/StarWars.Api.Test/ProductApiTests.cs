using StarWars.Api.Test.Configuration;
using StarWars.Api.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.Api.Test
{
    [TestCaseOrderer("StarWars.Api.Test.Configuration.PriorityOrderer", "StarWars.Api.Test")]
    public class rebeldeApiTests
    {
        #region Properties

        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly RebeldeViewModel _rebeldeFake;

        #endregion

        #region Constructors

        public rebeldeApiTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            _client = _server.CreateClient();

            _rebeldeFake = Newrebelde();
        }

        #endregion

        #region Public Methods

        [Fact, TestPriority(1)]
        public async Task rebelde_Create_Ok()
        {
            // Arrange
            var rebeldeJson = JsonConvert.SerializeObject(_rebeldeFake);
            var rebeldeContent = new StringContent(rebeldeJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/Rebelde/Create", rebeldeContent);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(2)]
        public async Task rebelde_Update_Ok()
        {
            // Arrange
            _rebeldeFake.Name = "Shampoo Update";
            var rebeldeJson = JsonConvert.SerializeObject(_rebeldeFake);
            var rebeldeContent = new StringContent(rebeldeJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/v1/Rebelde/Update", rebeldeContent);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(3)]
        public async Task rebelde_GetAll_Ok()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/Rebelde/RetornaTodos");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact, TestPriority(6)]
        public async Task rebelde_Create_WithOutSku()
        {
            // Arrange
            var rebeldeJson = JsonConvert.SerializeObject(NewrebeldeWithOutSku());
            var rebeldeContent = new StringContent(rebeldeJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/Rebelde/Create", rebeldeContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ResponseViewModel>(responseString);

            // Assert
            Assert.False(responseObject.Success);
            Assert.Contains(responseObject.Errors, x => x.Contains("Sku deve ser um valor entre 1 e 4294967295"));
        }

        [Fact, TestPriority(7)]
        public async Task rebelde_Create_WithOutName()
        {
            // Arrange
            var rebeldeJson = JsonConvert.SerializeObject(NewrebeldeWithOutName());
            var rebeldeContent = new StringContent(rebeldeJson, UnicodeEncoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/Rebelde/Create", rebeldeContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ResponseViewModel>(responseString);

            // Assert
            Assert.False(responseObject.Success);
            Assert.Contains(responseObject.Errors, x => x.Contains("Campo Name é obrigatório"));
        }

        #endregion

        #region Private Methods

        private static RebeldeViewModel Newrebelde()
        {
            return new RebeldeViewModel
            {
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventario = new InventarioViewModel
                {
                    Itens = new List<ItemViewModel> {
                        //new ItemViewModel{Locality = "SP", Quantity = 12, Type = "ECOMMERCE"},
                        //new ItemViewModel{Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
                    }
                },
            };
        }

        private static RebeldeViewModel NewrebeldeWithOutSku()
        {
            return new RebeldeViewModel
            {
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventario = new InventarioViewModel
                {
                    Itens = new List<ItemViewModel> {
                        //new ItemViewModel{Locality = "SP", Quantity = 12, Type = "ECOMMERCE"},
                        //new ItemViewModel{Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
                    }
                },
            };
        }

        private static RebeldeViewModel NewrebeldeWithOutName()
        {
            return new RebeldeViewModel
            {
                Inventario = new InventarioViewModel
                {
                    Itens = new List<ItemViewModel> {
                        //new ItemViewModel{Locality = "SP", Quantity = 12, Type = "ECOMMERCE"},
                        //new ItemViewModel{Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE"}
                    }
                },
            };
        }

        #endregion
    }
}