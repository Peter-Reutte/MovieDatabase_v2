using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class QueryHandlerRegistry : IQueryHandlerRegistry
    {
        private readonly Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

        public IEnumerable<Type> RegisteredQueries => _handlers.Keys;

        public IEnumerable<Type> RegisteredHandlers => _handlers.Values;

        public QueryHandlerRegistry Register<H>() where H : IQueryHandler
        {
            var supportedQueryTypes = TypeUtils.FindGenericInterfaces(typeof(H), typeof(IQueryHandler<,>));

            if (_handlers.Keys.Any(registeredType => supportedQueryTypes.Contains(registeredType)))
                throw new ArgumentException("The query handled by the received handler already has a registered handler.");

            foreach (var queryType in supportedQueryTypes)
            {
                _handlers.Add(queryType, typeof(H));
            }

            return this;
        }

        public Type HandlerFor(Type queryType)
        {
            Type handlerType = null;
            if (!_handlers.TryGetValue(queryType, out handlerType))
                throw new KeyNotFoundException("Not found handler");

            return handlerType;
        }
    }
}
