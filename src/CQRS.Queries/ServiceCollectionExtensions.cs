using CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS;

public static class ServiceCollectionExtensions
{
    public static void AddQueryProcessor(this IServiceCollection services, Action<QueryHandlerRegistry> action)
    {
        if (action == null)
        {
            throw new ArgumentNullException("action");
        }

        QueryHandlerRegistry queryHandlerRegistry = new QueryHandlerRegistry();
        action(queryHandlerRegistry);

        foreach (Type registeredHandler in queryHandlerRegistry.RegisteredHandlers)
        {
            services.AddScoped(registeredHandler);
        }

        services.AddSingleton((IQueryHandlerRegistry)queryHandlerRegistry);
        services.AddScoped<IQueryProcessor, QueryProcessor>();
    }
}
