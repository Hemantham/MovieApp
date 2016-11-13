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
    public class CinemaWorldService : WebJetBaseService, IMovieProviderService
    {             
        public async Task<IEnumerable<MovieInfo>> Search(SearchCriteria criteria)
        {
            var titles = await _httpService.GetAsync<MoviesList>("api/cinemaworld/movies");

            return titles.Movies
                    .Where(Filter(criteria))
                    .Take(_topN) //limit the number due to performance reasons ;
                    .Select(t => Map(t, "CinemaWorldService"));

            //var getDetail = titles.Select(async t =>
            //{
            //    await _httpService.GetAsync<WebjetMovieResult>($"api/cinemaworld/movie/{t.ID}");
            //    return Map(t, "CinemaWorldService");
            //});

            //return Task.WhenAll(getDetail).Result.Where(FilterDetail(criteria));        
            
        }

        public async Task<MovieInfo> Get(string id)
        {
            var result = await _httpService.GetAsync<WebjetMovieResult>($"api/cinemaworld/movie/{id}");
            return MapDetail(result, "CinemaWorldService");
        }
    }
}

