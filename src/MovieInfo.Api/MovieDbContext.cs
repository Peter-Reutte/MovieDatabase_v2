using Microsoft.EntityFrameworkCore;

namespace MovieInfo.Api;
public sealed class MovieDbContext : DbContext
{
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
            builder.Property(m => m.ConcurrencyToken).IsRequired().IsConcurrencyToken();
        });
    }
}
