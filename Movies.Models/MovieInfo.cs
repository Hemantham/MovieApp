using Movies.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MovieInfo
    {
        public MovieType Type { get; set; }
        public string  Id { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public string ImageUrl { get; set; }

        public string Provider { get; set; }

    }
}
