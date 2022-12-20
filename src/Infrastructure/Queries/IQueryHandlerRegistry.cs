using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IQueryHandlerRegistry
    {
        IEnumerable<Type> RegisteredQueries { get; }

        Type HandlerFor(Type type);
    }
}
