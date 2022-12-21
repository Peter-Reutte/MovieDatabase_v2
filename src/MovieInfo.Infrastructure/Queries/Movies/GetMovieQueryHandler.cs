using Microsoft.EntityFrameworkCore;
using MovieInfo.Queries.Movies;
using MovieInfo.Queries;

namespace MovieInfo.Infrastructure.Queries.Movies;

public sealed class GetMovieQueryHandler : IQueryHandler<GetMovieQuery, MovieView>
{
    private readonly MovieDbContext _context;

    public GetMovieQueryHandler(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<MovieView> Handle(GetMovieQuery query, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies
            .Include(m => m.MovieActors)
            .ThenInclude(ma => ma.Actor)
            .SingleOrDefaultAsync(m => m.Id == query.Id, cancellationToken);
        if (movie == null)
            return null;

        return new MovieView
        {
            Title = movie.Title,
            Rating = movie.Rating,
            Score = movie.Score,
            Description = movie.Description,
            RealeseDate = movie.RealeseDate,
            Actors = movie.MovieActors.Select(a => new ActorReference
            {
                Id = a.Actor.Id,
                Name = a.Actor.Name,
                Rating = a.Actor.Rating,
                Score = a.Actor.Score
            })
        };
    }
}
