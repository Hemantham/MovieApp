﻿using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.API
{
    public interface IMovieProviderService
    {
        Task<IEnumerable<MovieInfo>> Search(SearchCriteria criteria);

        Task<MovieInfo> Get(string id);
    }
}
