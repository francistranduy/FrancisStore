using FrancisStore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository
{
    public class FrancisStoreRepository : IFrancisStoreRepository
    {
        private readonly IFrancisStoreDbContext context;
        public FrancisStoreRepository(IFrancisStoreDbContext francisStoreDbContext)
        {
            context = francisStoreDbContext;
        }

        public TEntity GetById<TEntity>(long id) where TEntity : BaseEntity
        {
            return GetAll<TEntity>().Where(e => e.Id == id).FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return GetEntities<TEntity>().AsQueryable();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            GetEntities<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            GetEntities<TEntity>().Remove(entity);
        }

        private IDbSet<TEntity> GetEntities<TEntity>() where TEntity : class
        {
            return this.context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }
    }
}
