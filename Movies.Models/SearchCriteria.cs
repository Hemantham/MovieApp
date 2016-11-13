using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class SearchCriteria
    {
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string Title { get; set; }
       
    }
}
