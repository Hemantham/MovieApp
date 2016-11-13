using Movies.Models;
using Movies.Models.Enums;
using Movies.Services.Json.WebJet;
using Movies.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Services
{
    public class WebJetBaseService
    {
        protected HttpService _httpService;
        protected const int _topN = 10;

        public WebJetBaseService()
        {
            _httpService = new HttpService("http://webjetapitest.azurewebsites.net/", new Dictionary<string, string>() { { "x-access-token", "sjd1HfkjU83ksdsm3802k" } });
        }

        public WebJetBaseService(HttpService httpService)
        {
            _httpService = httpService;
        }
                

        protected MovieInfo Map(WebjetMovieResult t, string provider)
        {
            return new MovieInfo
            {
                Id = t.ID,
                ImageUrl = t.Poster,
                Title = t.Title,
                Type = (MovieType)Enum.Parse(typeof(MovieType), t.Type, true),
                Year = t.Year,
                //Price = decimal.Parse(t.Price),
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
                Awards = t.Awards,     
                Provider = provider,

            };
        }

        protected Func<WebjetMovieResult, bool> Filter(SearchCriteria criteria)
        {
            return r => (string.IsNullOrWhiteSpace(criteria?.Title) || r.Title.Contains(criteria?.Title));
        }

        protected Func<MovieInfoDetail, bool> FilterDetail(SearchCriteria criteria)
        {
            return r => (( criteria?.PriceMin == 0 || criteria?.PriceMin <= r.Price) &&
            (criteria.PriceMax == 0 || criteria.PriceMax >= r.Price));
        }
    }
}
