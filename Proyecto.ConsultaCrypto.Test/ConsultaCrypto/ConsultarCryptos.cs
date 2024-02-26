using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Proyecto.ConsultaCrypto.Entities.Tickers;
using Proyecto.ConsultaCrypto.Entities.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto.ConsultaCrypto.Test.ConsultaCrypto
{
    internal class TestConsultarCryptos
    {
        public abstract class IntegrationTestConsultarCryptos : IClassFixture<WebApplicationFactory<Program>>
        {
            protected readonly HttpClient Client;

            public IntegrationTestConsultarCryptos(WebApplicationFactory<Program> factory)
                => Client = factory.CreateDefaultClient();
        }

        public class TodoItemCreationEndpointTestConsultarCryptos : IntegrationTestConsultarCryptos
        {
            public TodoItemCreationEndpointTestConsultarCryptos(WebApplicationFactory<Program> factory)
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

                    var resultx = await Client.PostAsJsonAsync("api/ConsultasCryptos/Tickers", resultTicker);
                    //var resultx = await Client.GetFromJsonAsync("api/ConsultasCryptos/Tickers");
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
