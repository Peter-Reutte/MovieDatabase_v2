using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Infrastructure.Queries;

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
        });
    }
}

public sealed class Movie
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = null!;

    public int Rating { get; private set; }

    public double Score { get; private set; }
}
