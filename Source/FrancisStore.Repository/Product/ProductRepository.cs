using FrancisStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.Product
{
    public class ProductRepository : FrancisStoreRepository, IProductRepository
    {
        public ProductRepository(IFrancisStoreDbContext context): base(context)
        {
        }
    }
}
