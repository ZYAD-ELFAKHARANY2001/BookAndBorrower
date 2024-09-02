using BookAndBorrower.Application.Contract;
using BookAndBorrower.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookAndBorrower.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LibraryContext _libraryContext;
        public readonly DbSet<TEntity> _DbsetEntity;

        public DbSet<TEntity> DbsetEntitySet => _libraryContext.Set<TEntity>();
        public IQueryable<TEntity> GoTo => _libraryContext.Set<TEntity>();


        public Repository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            _DbsetEntity = libraryContext.Set<TEntity>();
        }
        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? criteria, int? skip, int? take)
        {
            IQueryable<TEntity> query = _libraryContext.Set<TEntity>();
            if (criteria != null)
            {
                query = _libraryContext.Set<TEntity>().Where(criteria);
            }
            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return query;
        }
        public int Complete()
        {
           return  _libraryContext.SaveChanges();
        }
    }
}
