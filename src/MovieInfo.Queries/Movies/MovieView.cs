using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Queries.Movies
{
    public sealed class MovieView
    {
        public string Title { get; set; } = null!;


        public int Rating { get; set; }

        public double Score { get; set; }
    }
}
