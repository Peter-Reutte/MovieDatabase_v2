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
            builder.Property(m => m.ConcurrencyToken).IsRequired().IsConcurrencyToken();
        });
    }


    internal sealed class Movie
    {
        public Guid Id { get; private set; }

        public string Title { get; private set; } = null!;

        public int Rating { get; private set; }

        public double Score { get; private set; }

        public Guid ConcurrencyToken { get; private set; }
    }
}
