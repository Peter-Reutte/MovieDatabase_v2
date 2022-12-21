namespace MovieInfo.Queries.Movies;

public sealed class MovieReference
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }

    public DateTime RealeseDate { get; set; }

    public string Description { get; set; } = null!;
}