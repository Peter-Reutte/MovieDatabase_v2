namespace MovieInfo.Domain.Actors;

public interface IActorRepository
{
    Task<Actor?> Get(Guid id, CancellationToken cancellationToken);

    Task Save(Actor actor);
}
