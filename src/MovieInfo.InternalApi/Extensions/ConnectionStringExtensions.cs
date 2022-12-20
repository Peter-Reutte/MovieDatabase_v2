using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.InternalApi.Extensions
{
    internal static class ConnectionStringExtensions
    {
        public static string AppendApplicationName(string connectionString)
        {
            var builder = new Npgsql.NpgsqlConnectionStringBuilder(connectionString);
            if (string.IsNullOrEmpty(builder.ApplicationName))
            {
                string? @namespace = typeof(ConnectionStringExtensions).Namespace;
                builder.ApplicationName = @namespace?.Remove(@namespace.LastIndexOf('.'));
            }

            return builder.ConnectionString;
        }
    }
}
