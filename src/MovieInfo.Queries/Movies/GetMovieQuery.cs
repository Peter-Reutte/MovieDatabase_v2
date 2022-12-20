//using Infrastructure.Queries;

namespace MovieInfo.Queries.Movies;

public sealed class GetMovieQuery : IQuery<MovieView>
{
    public GetMovieQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}