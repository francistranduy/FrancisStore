using FrancisStore.Data.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Bases
{
    public interface IGenericRepository<TEntity>: IDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(long id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Save();
        Task SaveAsync();
    }
}
