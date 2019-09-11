using FrancisStore.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Repositories
{
    public interface IFrancisStoreRepository: IDisposable
    {
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity GetById<TEntity>(long id) where TEntity : BaseEntity;
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();
    }
}
