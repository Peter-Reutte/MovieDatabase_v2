using Microsoft.EntityFrameworkCore;

namespace MovieInfo.Infrastructure.Queries.Actors;

public sealed class ActorDbContext : DbContext
{
    internal DbSet<Actor> Actors { get; set; }

    public ActorDbContext(DbContextOptions<ActorDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Actor>(builder =>
        {
            builder.ToTable("Actor");
            builder.HasKey(a => a.Id);

            builder.HasMany(m => m.MovieActors)
                .WithOne()
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(ma => ma.ActorId);
        });

        modelBuilder.Entity<Movie>(builder =>
        {
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
        });

        modelBuilder.Entity<MovieActor>(builder =>
        {
            builder.ToTable("MovieActor");
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });

            builder.HasOne(ma => ma.Movie)
                .WithOne()
                .HasPrincipalKey<Movie>(m => m.Id)
                .HasForeignKey<MovieActor>(ma => ma.ActorId);
        });
    }
}

public sealed class Movie
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = null!;

    public int Rating { get; private set; }

    public double Score { get; private set; }

    public DateTime RealeseDate { get; private set; }

    public string Description { get; private set; } = null!;
}

public sealed class Actor
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Rating { get; set; }

    public double Score { get; set; }

    public IEnumerable<MovieActor> MovieActors { get; private set; }
}

public sealed class MovieActor
{
    public Guid MovieId { get; set; }

    public Guid ActorId { get; set; }

    public Movie Movie { get; set; } = null!;
}
