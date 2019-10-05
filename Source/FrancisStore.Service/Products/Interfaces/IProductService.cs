using FrancisStore.Service.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Products.Interfaces
{
    public interface IProductService
    {
        Task<IList<Product>> GetPagedProductListAsync(string searchString = null, int page = 1, int pageSize = 12);
        Task<int> CountAsync(string searchString = null);
        Task<IList<Product>> GetPagedProductListByCollectionIdAsync(long id, string searchString = null, int page = 1, int pageSize = 12);
        Task<int> CountByCollectionIdAsync(long id, string searchString = null);
        Task<ProductDetails> GetProductDetailsAsync(long id);
        Task<Variant> GetVariantsByProductIdAndOptions(long id, IDictionary<string, string> options);
    }
}
