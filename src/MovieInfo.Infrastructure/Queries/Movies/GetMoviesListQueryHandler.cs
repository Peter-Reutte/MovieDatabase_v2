using Microsoft.EntityFrameworkCore;
using MovieInfo.Queries.Movies;
using MovieInfo.Queries;

namespace MovieInfo.Infrastructure.Queries.Movies;

public sealed class GetMoviesListQueryHandler : IQueryHandler<GetMoviesListQuery, IEnumerable<MovieReference>>
{
   private readonly MovieDbContext _context;

    public GetMoviesListQueryHandler(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovieReference>> Handle(GetMoviesListQuery query, CancellationToken cancellationToken)
    {
        var movies = await _context.Movies
            .Select(m => new MovieReference
            {
                Id = m.Id,
                Title = m.Title,
                Rating = m.Rating,
                Score = m.Score,
                Description = m.Description,
                RealeseDate = m.RealeseDate,
            })
            .ToListAsync(cancellationToken);

        if (query.SortByTitle)
            movies.OrderBy(m => m.Title);
        if (query.SortByScore)
            movies.OrderBy(m => m.Score);
        if (query.SortByDate)
            movies.OrderBy(m => m.RealeseDate);

        return movies;
    }
}
