using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IQueryProcessor
    {
        /// <summary>
        /// Процессор запроса - находит необходимый обработчик и вызывает его 
        /// </summary>
        /// <typeparam name="TResult">Требуемый результат</typeparam>
        /// <param name="query">Запрос для выполнения</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Результат запроса</returns>
        Task<TResult> Proccess<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);
    }
}
