namespace CQRS.Queries;

public interface IQueryHandlerRegistry
{
    IEnumerable<Type> RegisteredQueries { get; }

    Type HandlerFor(Type type);
}
