﻿using Movies.API;
using Movies.Models;
using Movies.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Movies.Rest.Controllers
{
    //[Authorize]
    public class MoviesController : ApiController
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpPost]
        [Route("api/movies/search")]
        public async Task<IEnumerable<MovieInfo>> Search(SearchCriteria criteria)
        {
            return await _movieService.Search(criteria) ;
        }

        [HttpGet]
        [Route("api/providers/{provider}/movies/{id}")]
        public async Task<MovieInfo> Get(string id, string provider)
        {
            return await _movieService.Get(id,provider);
        }



        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}