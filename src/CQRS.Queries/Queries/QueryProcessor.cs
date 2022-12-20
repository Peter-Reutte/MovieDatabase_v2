namespace CQRS.Queries;

public class QueryProcessor : IQueryProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IQueryHandlerRegistry _registry;

    public QueryProcessor(IServiceProvider serviceProvider, IQueryHandlerRegistry registry)
    {
        _serviceProvider = serviceProvider;
        _registry = registry;
    }

    public async Task<TResult> Proccess<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
    {
        Type handlerType = _registry.HandlerFor(query.GetType());
        dynamic queryHandler = _serviceProvider.GetService(handlerType);

        return await queryHandler.Handle((dynamic)query, cancellationToken);
    }
}
