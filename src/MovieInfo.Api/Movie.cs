using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Api
{
    public sealed class Movie
    {
        public Movie(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            Rating = 0;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public Guid ConcurrencyToken { get; set; }
    }
}
