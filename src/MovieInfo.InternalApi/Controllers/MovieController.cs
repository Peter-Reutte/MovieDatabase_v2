//using Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;
using MovieInfo.Domain.Movies;
using MovieInfo.InternalApi.Models;
using MovieInfo.Queries.Movies;

namespace MovieInfo.InternalApi.Controllers;

public sealed class MovieController : ControllerBase
{
    public MovieController() { }

    /// <summary>
    /// Add movie to list
    /// </summary>
    /// <param name="binding"></param>
    /// <param name="repository"></param>
    /// <returns></returns>
    [HttpPost("/movies")]
    public async Task<IActionResult> AddMovie(
        [FromBody] CreateMovieBinding binding,
        [FromServices] IMovieRepository repository)
    {
        var movie = new Movie(binding.Title);

        await repository.Save(movie);

        return NoContent();
    }

    /// <summary>
    /// Get movies list
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="processor"></param>
    /// <returns></returns>
    [HttpGet("/movies")]
    public async Task<ActionResult<IEnumerable<MovieReference>>> GetMoviesList(
        CancellationToken cancellationToken,
        //[FromServices] IQueryProcessor processor
        [FromServices] Infrastructure.Queries.GetMoviesListQueryHandler handler)
    {
        var movies = await handler.Handle(new GetMoviesListQuery(), cancellationToken);

        return Ok(movies);
    }

    /// <summary>
    /// Get info about movie
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="processor"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("/movies/{id}")]
    public async Task<ActionResult<MovieView>> GetMovie(
        CancellationToken cancellationToken,
        [FromServices] Infrastructure.Queries.GetMovieQueryHandler handler,
        //[FromServices] IQueryProcessor processor,
        [FromRoute] Guid id)
    {
        var movie = await handler.Handle(new GetMovieQuery(id), cancellationToken);
        if (movie == null)
            return StatusCode(404);

        return Ok(movie);
    }

    /// <summary>
    /// Update score
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="id"></param>
    /// <param name="binding"></param>
    /// <param name="repository"></param>
    /// <returns></returns>
    [HttpPatch("/movies/{id}")]
    public async Task<IActionResult> UpdateScore(
        CancellationToken cancellationToken,
        [FromRoute] Guid id,
        [FromBody] NewEstimateBinding binding,
        [FromServices] IMovieRepository repository)
    {
        var movie = await repository.Get(id, cancellationToken);
        if (movie == null)
            return StatusCode(404);

        movie.UpdateScore(binding.Estimate);

        await repository.Save(movie);

        return NoContent();
    }
}
