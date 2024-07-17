using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.Core.Consts;
using RepositoryPatternWithUnitOfWork.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Find(Expression<Func<T, bool>> expretion, string[] includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            }


            return query.SingleOrDefault(expretion);
        }

        public T GetById(int id)
        {

            var item = _dbSet.Find(id);
            return item;

        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip,
              Expression<Func<T, object>> orderby = null, string orderbydirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet.Where(match);
            if(take.HasValue)
            {
                query=query.Take(take.Value);

            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);

            }
            if (orderby != null)
            {
                if(orderbydirection == OrderBy.Descending)
                {
                    query = query.OrderByDescending(orderby);
                }
                else
                {
                    query = query.OrderBy(orderby);
                }
            }
            return query.ToList();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }
    }
}
