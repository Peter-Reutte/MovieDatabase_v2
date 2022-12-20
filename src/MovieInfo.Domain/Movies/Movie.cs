namespace MovieInfo.Domain.Movies;

public sealed class Movie
{
    public Movie(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Rating = 0;
        Score = 0;
        Description = description;
        RealeseDate = DateTime.UtcNow;

        ConcurrencyToken = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }

    public DateTime RealeseDate { get; set; }

    public string Description { get; set; } = null!;

    public Guid ConcurrencyToken { get; set; }

    public void UpdateScore(int estimate)
    {
        Rating++;

        Score = (Score + estimate) / Rating;

        ConcurrencyToken = Guid.NewGuid();
    }
}
