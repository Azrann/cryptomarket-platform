using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoMarketWeb.Services
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> PostAsync(object model, string baseUrl, string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                var serializedRequest = JsonConvert.SerializeObject(model);

                var request = new StringContent(serializedRequest);

                request.Headers.Clear();

                request.Headers.Add("Content-Type", "application/json");

                return await client.PostAsync(requestUri, request);
            }
        }

        public static async Task<HttpResponseMessage> PostAsync(object model, string baseUrl, string requestUri, string token = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);


                var serializedRequest = JsonConvert.SerializeObject(model);

                var request = new StringContent(serializedRequest);

                request.Headers.Clear();

                request.Headers.Add("Content-Type", "application/json");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.Headers.Add("Authentication-Info", $"Basic {token}");
                }
                return await client.PostAsync(requestUri, request);
            }
        }

        public static async Task<HttpResponseMessage> GetAsync(string baseUrl, string requestUri)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"{baseUrl}{requestUri}"),
                    Method = HttpMethod.Get,
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await client.SendAsync(request);
            }
        }

        public static async Task<HttpResponseMessage> GetAsync(string baseUrl, string requestUri, string token)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"{baseUrl}{requestUri}"),
                    Method = HttpMethod.Get,
                };
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.Headers.Add("Authentication-Info", $"Basic {token}");
                }

                return await client.SendAsync(request);
            }
        }
    }
}