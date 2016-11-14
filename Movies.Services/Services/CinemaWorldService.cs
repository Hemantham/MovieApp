using Movies.API;
using Movies.Models;
using Movies.Models.Enums;
using Movies.Services.Json.WebJet;
using Movies.Services.Services;
using Movies.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.API.API.Cache;
using Movies.Services.Cache;

namespace Movies.Services
{
    public class CinemaWorldService : WebJetBaseService, IMovieProviderService
    {

        public async Task<IEnumerable<MovieInfo>> Search(SearchCriteria criteria)
        {
            return await SearchProvider(criteria, "CinemaWorldService", "api/cinemaworld/movies");
        }

        public async Task<MovieInfo> Get(string id)
        {
            var result = await HttpService.GetAsync<WebjetMovieResult>($"api/cinemaworld/movie/{id}");
            return MapDetail(result, "CinemaWorldService");
        }
    }
}

