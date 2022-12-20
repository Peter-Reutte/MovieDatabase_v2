//using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using MovieInfo.Queries.Movies;

namespace MovieInfo.Infrastructure.Queries
{
    public sealed class GetMoviesListQueryHandler : IQueryHandler<GetMoviesListQuery, IEnumerable<MovieReference>>
    {
       private readonly MovieDbContext _context;

        public GetMoviesListQueryHandler(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieReference>> Handle(GetMoviesListQuery query, CancellationToken cancellationToken)
        {
            return await _context.Movies
                .Select(m => new MovieReference
                {
                    Id = m.Id,
                    Title = m.Title,
                    Rating = m.Rating,
                    Score = m.Score,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
