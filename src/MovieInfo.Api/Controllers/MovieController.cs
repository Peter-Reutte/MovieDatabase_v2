using Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;
using MovieInfo.Queries.Movies;

namespace MovieInfo.Api.Controllers
{
    public sealed class MovieController : ControllerBase
    {
        public MovieController() { }

        [HttpGet("/movies")]
        public async Task<ActionResult<IEnumerable<MovieView>>> GetMoviesList(CancellationToken cancellationToken,
            [FromServices] IQueryProcessor processor)
        {
            var movies = await processor.Proccess(new GetMoviesListQuery(), cancellationToken);

            return Ok(movies);
        }
    }
}
