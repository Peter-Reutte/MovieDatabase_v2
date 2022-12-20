using Microsoft.EntityFrameworkCore;

namespace MovieInfo.Infrastructure.Queries.Movies;

public sealed class MovieDbContext : DbContext
{
    internal DbSet<Movie> Movies { get; set; }

    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>(builder =>
        {
            builder.ToTable("Movie");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Rating).IsRequired();
            builder.Property(m => m.Score).IsRequired(); 
            builder.Property(m => m.RealeseDate).IsRequired();
            builder.Property(m => m.Description).IsRequired();
        });
    }
}

public sealed class Movie
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = null!;

    public int Rating { get; private set; }

    public double Score { get; private set; }

    public DateTime RealeseDate { get; set; }

    public string Description { get; set; } = null!;
}
