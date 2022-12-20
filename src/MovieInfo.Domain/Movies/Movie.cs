namespace MovieInfo.Domain.Movies;

public sealed class Movie
{
    public Movie(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        Rating = 0;

        ConcurrencyToken = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public int Rating { get; set; }

    public double Score { get; set; }

    public Guid ConcurrencyToken { get; set; }

    public void UpdateScore(int estimate)
    {
        Rating++;

        Score = (Score + estimate) / Rating;

        ConcurrencyToken = Guid.NewGuid();
    }
}
