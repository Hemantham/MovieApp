using Movies.Models;
using Movies.Models.Enums;
using Movies.Services.Json.WebJet;
using Movies.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Movies.API.API.Cache;
using Movies.Services.Cache;
using Movies.API.API.Utility;

namespace Movies.Services.Services
{
    public class WebJetBaseService
    {
        protected IHttpService HttpService;
        protected const int TopN = 20;
        protected readonly ICacheProvider CacheProvider;

        public WebJetBaseService()
        {
            CacheProvider = MemCachProvider.Instance;
            HttpService = new HttpService("http://webjetapitest.azurewebsites.net/", new Dictionary<string, string>() { { "x-access-token", "sjd1HfkjU83ksdsm3802k" } });
        }

        public WebJetBaseService(HttpService httpService)
        {
            HttpService = httpService;
        }
                

        protected async Task<MovieInfo> Map(WebjetMovieResult t, string provider)
        {
            return new MovieInfo
            {
                Id = t.ID,
                ImageUrl = t.Poster,
                Title = t.Title,
                Type = (MovieType)Enum.Parse(typeof(MovieType), t.Type, true),
                Year = t.Year,
               // ImageString = await  HttpService.GetImage(t.Poster),
                Provider = provider,
            };
        }

        protected MovieInfo MapDetail(WebjetMovieResult t, string provider)
        {
            return new MovieInfoDetail
            {
                Id = t.ID,
                ImageUrl = t.Poster,
                Title = t.Title,
                Type = (MovieType)Enum.Parse(typeof(MovieType), t.Type, true),
                Year = t.Year,
                Price = decimal.Parse(t.Price),
                Plot = t.Plot,
                Rated = t.Rated,
                Released = t.Released,
                Rating = t.Rating,
                Awards = t.Awards,     
                Provider = provider,
            };
        }

        protected async Task<IEnumerable<MovieInfo>> SearchProvider(SearchCriteria criteria, string provider, string api)
        {
            MoviesList titles = CacheProvider.GetItem<MoviesList>(provider);

            if (titles == null)
            {
                titles = await HttpService.GetAsync<MoviesList>(api);
                if (titles != null)
                {
                    CacheProvider.AddItem(provider, titles);
                }
                else
                {
                    return new List<MovieInfo>();
                }
            }            

            var @return = new List<MovieInfo>();

            foreach(var item in titles.Movies.Where(Filter(criteria)).Take(TopN))
            {
                var info = await Map(item, provider);
                               
                info.ImageString = await GetImage( info);

                @return.Add(info);
            }

            return @return;
        }

        protected async Task<string> GetImage(MovieInfo info)
        {
            var image = CacheProvider.GetItem<string>(info.Id);

            if (image == null)
            {
                image = await HttpService.GetImage(info.ImageUrl);

                if (image != null)
                {
                    CacheProvider.AddItem(info.Id, image);
                }
            }

            return image;
        }

        protected Func<WebjetMovieResult, bool> Filter(SearchCriteria criteria)
        {
            return r => (string.IsNullOrWhiteSpace(criteria?.Title) || Regex.IsMatch(r.Title, criteria.Title, RegexOptions.IgnoreCase));
        }

        protected Func<MovieInfoDetail, bool> FilterDetail(SearchCriteria criteria)
        {
            return r => (( criteria?.PriceMin == 0 || criteria?.PriceMin <= r.Price) &&
            (criteria.PriceMax == 0 || criteria.PriceMax >= r.Price));
        }
    }
}
