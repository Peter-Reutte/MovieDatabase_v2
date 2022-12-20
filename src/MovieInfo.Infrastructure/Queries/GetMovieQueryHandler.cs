//using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using MovieInfo.Queries.Movies;

namespace MovieInfo.Infrastructure.Queries;

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
            .SingleOrDefaultAsync(m => m.Id == query.Id, cancellationToken);
        if (movie == null)
            return null;

        return new MovieView
        {
            Title = movie.Title,
            Rating = movie.Rating,
            Score = movie.Score,
        };
    }
}
