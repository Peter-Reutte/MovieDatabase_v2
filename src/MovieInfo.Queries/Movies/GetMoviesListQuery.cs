using System;
using System.Collections.Generic;
//using Infrastructure.Queries;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Queries.Movies
{
    public sealed class GetMoviesListQuery : IQuery<IEnumerable<MovieReference>>
    { }
}
