using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAndBorrower.Application.Contract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> DbsetEntitySet { get; }
        IQueryable<TEntity> GoTo { get;  }
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? criteria, int? skip, int? take);
        public int Complete();

    }
}
