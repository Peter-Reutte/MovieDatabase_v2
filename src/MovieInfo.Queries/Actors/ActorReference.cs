using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Queries.Actors
{
    public sealed class ActorReference
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int Rating { get; set; }

        public double Score { get; set; }
    }
}
