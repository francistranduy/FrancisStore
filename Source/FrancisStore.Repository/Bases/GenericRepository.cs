using FrancisStore.Data;
using FrancisStore.Data.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Bases
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        private readonly IFrancisStoreDbContext _context;

        public GenericRepository(IFrancisStoreDbContext context)
        {
            _context = context;
        }

        protected IFrancisStoreDbContext DbContext
        {
            get
            {
                return _context;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetEntities().AsQueryable();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await GetEntities().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return GetEntities().Where(predicate);
        }

        public void Insert(TEntity entity)
        {
            GetEntities().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            GetEntities().Remove(entity);
        }

        public void Save()
        {
            this.DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await this.DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (this.DbContext != null)
            {
                this.DbContext.Dispose();
            }
        }

        #region [Private Method]
        private IDbSet<TEntity> GetEntities()
        {
            return this.DbContext.Set<TEntity>();
        }
        #endregion
    }
}
