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

namespace Movies.Services
{
    public class FilmWorldService : WebJetBaseService, IMovieProviderService
    {             
        public async Task<IEnumerable<MovieInfo>> Search(SearchCriteria criteria)
        {
            return await SearchProvider(criteria, "FilmWorldService", "api/filmworld/movies");
        }

        public async Task<MovieInfo> Get(string id)
        {
            var result =  await HttpService.GetAsync<WebjetMovieResult>($"api/filmworld/movie/{id}");

            var detail =  MapDetail(result, "FilmWorldService");

            detail.ImageString = await GetImage(detail);

            return detail;
        }
    }
}

