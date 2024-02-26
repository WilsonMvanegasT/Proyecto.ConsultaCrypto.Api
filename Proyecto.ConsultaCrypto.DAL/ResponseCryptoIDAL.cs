using Proyecto.ConsultaCrypto.Entities.Tickers;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto.ConsultaCrypto.DAL
{
    public class ResponseCryptoIDAL
    {
        public async Task<Ticker> GetCryptoData()
        {
            
            // URL base de la API de CoinLore
            string baseUrl = "https://api.coinlore.com/api/";

            // Endpoint para obtener la lista de las primeras 100 criptomonedas
            string endpoint = "tickers/?start=0&limit=6";

            // Crear cliente HTTP
            using var client = new HttpClient();

            // Crear el objeto para deserializar y retornar los datos
            Ticker data = new Ticker();
           
            try
            {
                // Realizar la solicitud GET a la API
                HttpResponseMessage response = await client.GetAsync(baseUrl + endpoint);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido JSON de la respuesta
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Imprimir el resultado en la consola (puedes manejar estos datos como desees)
                    Console.WriteLine(responseBody);

                    // Deserializar la respuesta para armar objeto json tipo Ticker
                     data = JsonConvert.DeserializeObject<Ticker>(responseBody);
                }
                else
                {
                    // Si la solicitud no fue exitosa, mostrar el código de estado
                    Console.WriteLine("Error al hacer la solicitud. Código de estado: " + response.StatusCode);
                }
                return data;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y mostrarla
                Console.WriteLine("Error: " + ex.Message);
                throw;
               
            }
        }

        public async Task<object> GetSpecificCryptoData(string id)
        {
            // URL base de la API de CoinLore
            string baseUrl = "https://api.coinlore.com/api/";

            // Endpoint para obtener la informacion de una lista de id's
            string endpoint = "ticker/?id=";

            // Crear cliente HTTP
            using var client = new HttpClient();

            // Crear el objeto para deserializar la respuesta y retornar los datos
            // Data data = new Data();
            object data = null;

            try
            {
                // Realizar la solicitud GET a la API
                HttpResponseMessage response = await client.GetAsync(baseUrl + endpoint + id);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido JSON de la respuesta
                   string responseBody = await response.Content.ReadAsStringAsync();

                    // Imprimir el resultado en la consola (puedes manejar estos datos como desees)
                    Console.WriteLine(responseBody);

                    // Deserializar la respuesta para armar objeto json tipo Ticker
                     data = JsonConvert.DeserializeObject<List<Data>>(responseBody);
                    //data = JsonConvert.DeserializeObject<Data>(responseBody);
                }
                else
                {
                    // Si la solicitud no fue exitosa, mostrar el código de estado
                    Console.WriteLine("Error al hacer la solicitud. Código de estado: " + response.StatusCode);
                }
                return data;
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y mostrarla
                Console.WriteLine("Error: " + ex.Message);
                throw;                
            }
        }

    }
}
