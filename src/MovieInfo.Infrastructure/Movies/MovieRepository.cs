using Microsoft.EntityFrameworkCore;
using MovieInfo.Domain.Movies;

namespace MovieInfo.Infrastructure.Movies;

public sealed class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _context;

    public MovieRepository(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<Movie?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task Save(Movie movie)
    {
        if (_context.Entry(movie).State == EntityState.Detached)
            _context.Movies.Add(movie);

        await _context.SaveChangesAsync();
    }
}
