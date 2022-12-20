using Microsoft.EntityFrameworkCore;
using MovieInfo.Domain.Actors;

namespace MovieInfo.Infrastructure.Actors;

public sealed class ActorRepository : IActorRepository
{
    private readonly ActorDbContext _context;

    public ActorRepository(ActorDbContext context)
    {
        _context = context;
    }

    public async Task<Actor?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Actors
            .SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task Save(Actor actor)
    {
        if (_context.Entry(actor).State == EntityState.Detached)
            _context.Actors.Add(actor); 

        await _context.SaveChangesAsync();
    }
}
