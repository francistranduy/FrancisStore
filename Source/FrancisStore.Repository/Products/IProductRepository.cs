using FrancisStore.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Products
{
    public interface IProductRepository : IFrancisStoreRepository
    {
        IQueryable<Product> GetAll();
        Task<Product> GetById(long id);
    }
}
