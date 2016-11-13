using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Json.WebJet
{
    public class MoviesList
    {
        public IEnumerable<WebjetMovieResult> Movies { get; set; }
    }
}
