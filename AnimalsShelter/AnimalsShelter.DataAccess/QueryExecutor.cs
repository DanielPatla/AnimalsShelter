using AnimalsShelter.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly AnimalsShelterStorageContext _context;

        public QueryExecutor(AnimalsShelterStorageContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}
