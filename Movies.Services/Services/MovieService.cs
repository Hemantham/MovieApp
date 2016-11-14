using Movies.API;
using Movies.Models;
using Movies.Models.Enums;
using Movies.Services.Json.WebJet;
using Movies.Services.Services;
using Movies.Services.Utility;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{

    /// <summary>
    /// this is the abstracted class which wraps calls to all other movie provider services
    /// at the moment it wraps cinemaworld and movieworld
    /// </summary>
    public class MovieService : IMovieService
    {
        readonly IMovieProviderService _cinemaWorld;
        readonly IMovieProviderService _filmWorld;

        public MovieService(
            [Named("CinemaWorldService")]IMovieProviderService cinemaWorld, 
            [Named("FilmWorldService")] IMovieProviderService filmWorld)
        {
            _cinemaWorld = cinemaWorld;
            _filmWorld = filmWorld;
        }

        public async Task<IEnumerable<MovieInfo>> Search(SearchCriteria criteria)
        {
            var movies = new List<MovieInfo>();
            movies.AddRange( await _cinemaWorld.Search(criteria));
            movies.AddRange(await _filmWorld.Search(criteria));
            return movies;
        }

        public async Task<MovieInfo> Get(string id, string provider)
        {
            switch(provider)
            {
                case "FilmWorldService": return await _filmWorld.Get(id);
                case "CinemaWorldService": return await _cinemaWorld.Get(id);
            }

            return null;
        }
    }
}

