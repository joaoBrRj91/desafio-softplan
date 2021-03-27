using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SoftPlan.Core.ClientConsumersApps.Http
{
    public class AppHttpClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        private readonly string _contentType;

        public readonly string baseAddress;

        public AppHttpClient(string contentType = "application/json")
        {
            _httpClient = new HttpClient();
            _contentType = contentType;
            baseAddress = Environment.GetEnvironmentVariable("API_TAXA_JUROS_URL");
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
