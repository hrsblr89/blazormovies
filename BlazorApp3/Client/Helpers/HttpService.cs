using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp3.Client.Helpers
{
    public class HttpService: IHttpService
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions defaultjsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHttp, defaultjsonSerializerOptions);
                return new HttpResponseWrapper<T>(response, true, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, false, responseHttp);
            }
        }


        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response,defaultjsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, false, response);
            }
            
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
