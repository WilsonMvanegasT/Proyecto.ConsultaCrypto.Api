using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Proyecto.ConsultaCrypto.Entities.Tickers;
using Proyecto.ConsultaCrypto.Entities.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.Testing;
using static Proyecto.ConsultaCrypto.Test.ConsultaCrypto.TestConsultarCryptos;

namespace Proyecto.ConsultaCrypto.Test.ConsultarCryuptoID
{
    internal class TestConsultarCryuptoID
    {
        public abstract class IntegrationTestConsultarCryuptoID : IClassFixture<WebApplicationFactory<Program>>
        {
            protected readonly HttpClient Client;

            public IntegrationTestConsultarCryuptoID(WebApplicationFactory<Program> factory)
                => Client = factory.CreateDefaultClient();
        }

        public class TodoItemCreationEndpointTestConsultarCryuptoID : IntegrationTestConsultarCryuptoID
        {
            public TodoItemCreationEndpointTestConsultarCryuptoID(WebApplicationFactory<Program> factory)
                : base(factory) { }

            [Fact]
            public async Task CreateConsultarCryptos()
            {
                try
                {
                    var resultTicker = new Data
                    {
                        id = "",
                        symbol = "",
                        name = "",
                        nameid = "",
                        rank = 0,
                        price_usd = "",
                        percent_change_24h = "",
                        percent_change_1h = "",
                        percent_change_7d = "",
                        price_btc = "",
                        market_cap_usd = "",
                        volume24 = "",
                        volume24a = "",
                        csupply = "",
                        tsupply = "",
                        msupply = "",
                    };

                    var resultx = await Client.PostAsJsonAsync("api/ConsultarTicker/IdTicker", resultTicker);
               
                    resultx.EnsureSuccessStatusCode();
                    // Leer y deserializar la respuesta
                    var content = await resultx.Content.ReadFromJsonAsync<ClsResponseOut<List<Data>>>();

                    // Assert
                    Assert.Equal(HttpStatusCode.OK, resultx.StatusCode);
                    Assert.NotNull(content);
                    Assert.Equal(9407, content.Result[0]?.rank);
                }
                catch (Exception)
                {
                    Assert.True(false);
                }
            }
        }

    }
}
   