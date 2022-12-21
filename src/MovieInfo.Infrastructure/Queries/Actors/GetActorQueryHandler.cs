using Microsoft.EntityFrameworkCore;
using MovieInfo.Queries.Actors;
using MovieInfo.Queries;

namespace MovieInfo.Infrastructure.Queries.Actors;

public sealed class GetActorQueryHandler : IQueryHandler<GetActorQuery, ActorView>
{
    private readonly ActorDbContext _context;

    public GetActorQueryHandler(ActorDbContext context)
    {
        _context = context;
    }

    public async Task<ActorView> Handle(GetActorQuery query, CancellationToken cancellationToken)
    {
        var actor = await _context.Actors
            .Include(m => m.MovieActors)
            .ThenInclude(ma => ma.Movie)
            .SingleOrDefaultAsync(m => m.Id == query.Id, cancellationToken);
        if (actor == null)
            return null;

        return new ActorView
        {
            Name = actor.Name,
            Rating = actor.Rating,
            Score = actor.Score,
            Movies = actor.MovieActors.Select(a => new MovieReference
            {
                Id = a.Movie.Id,
                Title = a.Movie.Title,
                Rating = a.Movie.Rating,
                Score = a.Movie.Score,
                Description = a.Movie.Description,
                RealeseDate = a.Movie.RealeseDate,
            })
        };
    }
}
