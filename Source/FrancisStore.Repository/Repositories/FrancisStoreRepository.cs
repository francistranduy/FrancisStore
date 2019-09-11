using FrancisStore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Repositories
{
    public class FrancisStoreRepository : IFrancisStoreRepository
    {
        private readonly IFrancisStoreDbContext _context;
        protected IFrancisStoreDbContext DbContext
        {
            get
            {
                return _context;
            }
        }
        public FrancisStoreRepository(IFrancisStoreDbContext francisStoreDbContext)
        {
            _context = francisStoreDbContext;
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
            return this.DbContext.Set<TEntity>();
        }

        public void SaveChanges()
        {
            this.DbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (this.DbContext != null)
            {
                this.DbContext.Dispose();
            }
        }
    }
}
