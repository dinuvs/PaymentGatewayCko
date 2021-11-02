using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Utils
{
    public class RestClient : IRestClient
    {
        public async Task<string> GetAsync(string url)
        {

            HttpClient client = new();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return string.Empty;
            }
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        public async Task<string> PostAsync<TIn>(string uri, TIn content)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await client.PostAsync(uri, serialized))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                    // return JsonConvert.DeserializeObject<TOut>(responseBody);
                }
            }
        }
    }
}
