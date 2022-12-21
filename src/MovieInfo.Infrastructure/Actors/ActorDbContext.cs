using Microsoft.EntityFrameworkCore;
using MovieInfo.Domain.Actors;

namespace MovieInfo.Infrastructure.Actors;

public sealed class ActorDbContext : DbContext
{
    internal DbSet<Actor> Actors { get; set; }

    public ActorDbContext(DbContextOptions<ActorDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>(builder =>
        {
            builder.ToTable(nameof(Movie));

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Rating).IsRequired();
            builder.Property(m => m.Score).IsRequired();
            builder.Property(m => m.RealeseDate).IsRequired();
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.ConcurrencyToken).IsRequired().IsConcurrencyToken();
        });

        modelBuilder.Entity<Actor>(builder =>
        {
            builder.ToTable(nameof(Actor));

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Rating).IsRequired();
            builder.Property(a => a.Score).IsRequired();
            builder.Property(a => a.ConcurrencyToken).IsRequired().IsConcurrencyToken();

            builder.HasMany(m => m.Movies)
                .WithMany(a => a.Actors);
        });

        modelBuilder.Entity<MovieActor>(builder =>
        {
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });
        });
    }
}

