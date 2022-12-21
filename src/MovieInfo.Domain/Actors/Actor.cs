namespace MovieInfo.Domain.Actors;

public sealed class Actor
{
    public Actor(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Rating = 0;
        Score = 0;

        ConcurrencyToken = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }

    public Guid ConcurrencyToken { get; set; }

    private List<Movie> _movies = new();
    public IEnumerable<Movie> Movies => _movies.AsReadOnly();

    public void UpdateScore(int estimate)
    {
        Rating++;

        Score = (Score + estimate) / Rating;

        ConcurrencyToken = Guid.NewGuid();
    }
}
