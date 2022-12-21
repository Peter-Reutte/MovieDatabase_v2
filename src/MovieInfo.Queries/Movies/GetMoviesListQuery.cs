namespace MovieInfo.Queries.Movies;

public sealed class GetMoviesListQuery : IQuery<IEnumerable<MovieReference>>
{
    public GetMoviesListQuery(bool sortByTitle, bool sortByScore, bool sortByDate)
    {
        SortByTitle = sortByTitle;
        SortByScore = sortByScore;
        SortByDate = sortByDate;
    }

    public bool SortByTitle { get; set; }

    public bool SortByScore { get; set; }

    public bool SortByDate { get; set; }
}
