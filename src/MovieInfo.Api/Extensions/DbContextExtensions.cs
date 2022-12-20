using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MovieInfo.Api.Extensions;

internal static class DbContextExtensions
{
    public static IServiceCollection AddNpgsqlDbContext<TDbContext>(this IServiceCollection services, string connectionString) where TDbContext : DbContext
        => services.AddDbContext<TDbContext>(options =>
        {
            options.UseNpgsql(ConnectionStringExtensions.AppendApplicationName(connectionString));
        });
}
