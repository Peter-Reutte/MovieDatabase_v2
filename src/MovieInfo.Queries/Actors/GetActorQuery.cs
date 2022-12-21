namespace MovieInfo.Queries.Actors;

public sealed class GetActorQuery : IQuery<ActorView>
{
    public GetActorQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
