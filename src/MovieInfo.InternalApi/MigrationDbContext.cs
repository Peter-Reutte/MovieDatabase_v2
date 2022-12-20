using Microsoft.EntityFrameworkCore;

namespace MovieInfo.InternalApi;

public sealed class MigrationDbContext : DbContext
{
    public MigrationDbContext(DbContextOptions<MigrationDbContext> options) 
        : base(options)
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
        });

        modelBuilder.Entity<MovieActor>(builder =>
        {
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });

            //modelBuilder.Entity<MovieActor>()
            //    .HasOne(pc => pc.Person)
            //    .WithMany(p => p.PersonClubs)
            //    .HasForeignKey(pc => pc.PersonId);

            //modelBuilder.Entity<MovieActor>()
            //    .HasOne(pc => pc.Club)
            //    .WithMany(c => c.PersonClubs)
            //    .HasForeignKey(pc => pc.ClubId);
        });
    }


    internal sealed class Movie
    {
        public Guid Id { get; private set; }

        public string Title { get; private set; } = null!;

        public int Rating { get; private set; }

        public double Score { get; private set; }

        public DateTime RealeseDate { get; set; }

        public string Description { get; set; } = null!;

        public Guid ConcurrencyToken { get; private set; }
    }

    internal sealed class Actor
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = null!;

        public int Rating { get; private set; }

        public double Score { get; private set; }

        public Guid ConcurrencyToken { get; private set; }
    }

    internal sealed class MovieActor
    {
        public Guid MovieId { get; private set; }

        public Guid ActorId { get; private set; }
    }
}
