using Microsoft.EntityFrameworkCore;
using MovieInfo.Queries;
using MovieInfo.Queries.Actors;

namespace MovieInfo.Infrastructure.Queries.Actors;

public sealed class GetActorsListQueryHandler : IQueryHandler<GetActorsListQuery, IEnumerable<ActorReference>>
{
    private readonly ActorDbContext _context;

    public GetActorsListQueryHandler(ActorDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ActorReference>> Handle(GetActorsListQuery query, CancellationToken cancellationToken)
    {
        return await _context.Actors
            .Select(a => new ActorReference
            {
                Id = a.Id,
                Name = a.Name,
                Rating = a.Rating,
                Score = a.Score
            })
            .OrderBy(m => m.Name)
            .ToListAsync(cancellationToken);
    }
}
