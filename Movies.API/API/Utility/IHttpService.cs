using System.Threading.Tasks;

namespace Movies.API.API.Utility
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string uri) where T : class, new();
        Task<string> GetImage(string uri);
    }
}