namespace MovieInfo.Domain.Movies;

public sealed class Actor
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }

    public Guid ConcurrencyToken { get; set; }

    private List<MovieActor> _movies = new();
    public IEnumerable<MovieActor> Movies => _movies.AsReadOnly();
}
