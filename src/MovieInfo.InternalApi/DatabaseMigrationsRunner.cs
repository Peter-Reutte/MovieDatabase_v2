using Microsoft.EntityFrameworkCore;

namespace MovieInfo.InternalApi
{
    public static class DatabaseMigrationsRunner
    {
        public static IHost RunDatabaseMigrations(this IHost host)
        {
            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MigrationDbContext>();
                var loggerFactory = serviceScope.ServiceProvider.GetRequiredService<ILoggerFactory>();

                var logger = loggerFactory.CreateLogger("DatabaseMigrations");

                logger.LogInformation("Starting migrations...");

                try
                {
                    context.Database.Migrate();

                    logger.LogInformation("Migrations ended. Awaiting cancel...");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Migrations failed");
                    throw;
                }

                return host;
            }
        }
    }
}
