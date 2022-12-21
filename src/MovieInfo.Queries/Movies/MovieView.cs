namespace MovieInfo.Queries.Movies;

public sealed class MovieView
{
    public string Title { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }

    public DateTime RealeseDate { get; set; }

    public string Description { get; set; } = null!;

    public IEnumerable<ActorReference> Actors { get; set; }
}

public sealed class ActorReference
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }
}
