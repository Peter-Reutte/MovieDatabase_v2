namespace MovieInfo.Domain.Actors;

public sealed class Movie
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }

    public DateTime RealeseDate { get; set; }

    public string Description { get; set; } = null!;

    public Guid ConcurrencyToken { get; set; }

    private List<MovieActor> _actors = new();
    public IEnumerable<MovieActor> Actors => _actors.AsReadOnly();
}
