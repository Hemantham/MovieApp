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
            var  titles = await _httpService.GetAsync<MoviesList>("api/filmworld/movies");

            return titles.Movies
                    .Where(Filter(criteria))
                    .Take(_topN)//limit the number due to performance reasons ;
                    .Select(t => Map(t, "FilmWorldService"));


            //var getDetail = titles.Select(async t =>
            //{
            //    await _httpService.GetAsync<WebjetMovieResult>($"api/filmworld/movie/{t.ID}");
            //    return Map(t, "FilmWorldService");
            //});

            //return Task.WhenAll(getDetail).Result.Where(FilterDetail(criteria));            
        }

        public async Task<MovieInfo> Get(string id)
        {
            var result =  await _httpService.GetAsync<WebjetMovieResult>($"api/filmworld/movie/{id}");
            return MapDetail(result, "FilmWorldService");
        }
    }
}

