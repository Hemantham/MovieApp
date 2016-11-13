using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Utility
{
    public class HttpService
    {
        private string _host;
        private IDictionary<string, string> _headers;
        private HttpClient _httpClient;

        public HttpService( string host, IDictionary<string, string> headers)
        {
            _host = host;
            _headers = headers;
            _httpClient = new HttpClient();

            foreach(var header in _headers)
            {
                  _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _httpClient.GetAsync( $"{_host}{uri}");

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
         
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(content));
        }
    }
}
