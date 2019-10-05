using FrancisStore.Data;
using FrancisStore.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Products
{
    public class ProductCollectionRepository : FrancisStoreRepository, IProductCollectionRepository
    {
        public ProductCollectionRepository(IFrancisStoreDbContext francisStoreDbContext) : base(francisStoreDbContext)
        {
        }

        public IQueryable<Collection> GetAll()
        {
            return this.GetAll<Collection>();
        }

        public Task<Collection> GetById(long id)
        {
            return this.GetById<Collection>(id);
        }
    }
}
