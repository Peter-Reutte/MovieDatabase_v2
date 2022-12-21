using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Queries.Actors
{
    public sealed class ActorView
    {
        public string Name { get; set; } = null!;

        public int Rating { get; set; }

        public double Score { get; set; }

        public IEnumerable<MovieReference> Movies { get; set; }
    }

    public sealed class MovieReference
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public int Rating { get; set; }

        public double Score { get; set; }

        public DateTime RealeseDate { get; set; }

        public string Description { get; set; } = null!;
    }
}
