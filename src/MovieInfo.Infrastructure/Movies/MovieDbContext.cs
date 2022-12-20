using Microsoft.EntityFrameworkCore;
using MovieInfo.Domain.Movies;

namespace MovieInfo.Infrastructure.Movies;

public sealed class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
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
    }
}
