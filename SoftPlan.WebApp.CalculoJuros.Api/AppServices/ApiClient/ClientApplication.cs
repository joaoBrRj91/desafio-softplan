using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SoftPlan.WebApp.CalculoJuros.Api.AppServices.ApiClient
{
    public class ClientApplication : IDisposable
    {
        private readonly HttpClient _httpClient;

        private readonly string _contentType;

        public ClientApplication(string baseAddress = "" , string contentType = "application/json")
        {
            _httpClient = new HttpClient();
            _contentType = contentType;
            ConfigureClient();
        }

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }

        private void ConfigureClient()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_contentType ?? "application/json"));

        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
