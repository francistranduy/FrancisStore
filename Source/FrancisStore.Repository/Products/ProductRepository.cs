using FrancisStore.Data;
using FrancisStore.Data.Entities.Products;
using FrancisStore.Repository.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Products
{
    public class ProductRepository : FrancisStoreRepository, IProductRepository
    {
        public ProductRepository(IFrancisStoreDbContext francisStoreDbContext) : base(francisStoreDbContext)
        {
        }

        public IQueryable<Product> GetAll()
        {
            return this.GetAll<Product>();
        }

        public Task<Product> GetById(long id)
        {
            return this.GetById<Product>(id);
        }
    }
}
