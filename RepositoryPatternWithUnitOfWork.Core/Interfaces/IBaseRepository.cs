using RepositoryPatternWithUnitOfWork.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        T Find(Expression<Func<T, bool>> expretion, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip,
            Expression<Func<T, object>> orderby = null, string orderbydirection = OrderBy.Ascending);

        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
    }
}
