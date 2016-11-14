using Movies.API.API.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Utility
{
    public class HttpService : IHttpService
    {
        private readonly string _host;
        private IDictionary<string, string> _headers;
        private readonly HttpClient _httpClient;

        public HttpService(string host, IDictionary<string, string> headers)
        {
            _host = host;
            _headers = headers;
            _httpClient = new HttpClient {Timeout = TimeSpan.FromMilliseconds(8000)};

            foreach (var header in _headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public async Task<T> GetAsync<T>(string uri) where T: class, new()
        {
            try
            {
           
            var response = await _httpClient.GetAsync( $"{_host}{uri}");

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
         
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(content));

            }
            catch (Exception) //todo handle exceptions types properly
            {
                return null;
            }
        }

        public async Task< string> GetImageAsync(string uri)
        {
            try
            {           
                var stream = await  _httpClient.GetStreamAsync(uri);
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                return  Convert.ToBase64String(memoryStream.ToArray());

            }
            catch (Exception)
            {
                return null;
            }
        }

      
    }
}
