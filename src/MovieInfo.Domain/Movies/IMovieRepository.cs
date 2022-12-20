namespace MovieInfo.Domain.Movies;

public interface IMovieRepository
{
    Task<Movie?> Get(Guid id, CancellationToken cancellationToken);

    Task Save(Movie movie);
}
