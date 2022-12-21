using Microsoft.AspNetCore.Mvc;
using MovieInfo.Domain.Actors;
using MovieInfo.InternalApi.Models;
using MovieInfo.Queries.Actors;

namespace MovieInfo.InternalApi.Controllers;

public sealed class ActorController : ControllerBase
{
    /// <summary>
    /// Add actor
    /// </summary>
    /// <param name="binding"></param>
    /// <param name="repository"></param>
    /// <returns></returns>
    [HttpPost("/actors")]
    public async Task<IActionResult> AddActor(
       [FromBody] AddActorBinding binding,
       [FromServices] IActorRepository repository)
    {
        var actor = new Actor(binding.Name);

        await repository.Save(actor);

        return NoContent();
    }

    /// <summary>
    /// Get actors list
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="processor"></param>
    /// <returns></returns>
    [HttpGet("/actors")]
    public async Task<ActionResult<IEnumerable<ActorReference>>> GetActorsList(
        CancellationToken cancellationToken,
        [FromServices] Infrastructure.Queries.Actors.GetActorsListQueryHandler handler,
        [FromQuery] bool byTitle = false,
        [FromQuery] bool byScore = false,
        [FromQuery] bool byDate = false)
    {
        var movies = await handler.Handle(new GetActorsListQuery(), cancellationToken);

        return Ok(movies);
    }

    /// <summary>
    /// Get info about actor
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="processor"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("/actors/{id}")]
    public async Task<ActionResult<ActorView>> GetActor(
        CancellationToken cancellationToken,
        [FromServices] Infrastructure.Queries.Actors.GetActorQueryHandler handler,
        [FromRoute] Guid id)
    {
        var movie = await handler.Handle(new GetActorQuery(id), cancellationToken);
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
    [HttpPatch("/actors/{id}")]
    public async Task<IActionResult> UpdateScore(
        CancellationToken cancellationToken,
        [FromRoute] Guid id,
        [FromBody] NewEstimateBinding binding,
        [FromServices] IActorRepository repository)
    {
        var actor = await repository.Get(id, cancellationToken);
        if (actor == null)
            return StatusCode(404);

        actor.UpdateScore(binding.Estimate);

        await repository.Save(actor);

        return NoContent();
    }
}
