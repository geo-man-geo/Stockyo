using Microsoft.AspNetCore.DataProtection.Repositories;
using StocksApp.FinhubContracts;
using System.Net.Http;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace StocksApp.Services
{
    public class FinhubService : IFinhubServices
    { 
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public FinhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory= httpClientFactory;  
            _configuration= configuration;  
        }

        public async Task<Dictionary<string,object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage() 
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinhubToken"]}"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader= new StreamReader(stream);
                string responseBody = streamReader.ReadToEnd();
                Dictionary<string,object>? response = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);

                if (response == null)
                    throw new InvalidOperationException("No response from the Finhub server");
                if(response.ContainsKey("error"))
                    throw new InvalidOperationException(Convert.ToString(response["error"]));   

                return response;
            }
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            using(HttpClient httpClient = _httpClientFactory.CreateClient()) 
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["FinhubToken"]}"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                string responseBody = streamReader.ReadToEnd();
                Dictionary<string, object>? response = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);

                if (response == null)
                    throw new InvalidOperationException("No response from the Finhub server");
                if (response.ContainsKey("error"))
                    throw new InvalidOperationException(Convert.ToString(response["error"]));

                return response;
            }
        }

    }
}
    