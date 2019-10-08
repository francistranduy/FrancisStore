using FrancisStore.Service.Products.Models;
using FrancisStore.Service.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Shopping.Interfaces
{
    public interface IShoppingCartService
    {
        Task AddToCart(Variant variant);
        Task<int> RemoveItem(long itemId);
        Task Clear();
        Task<IList<Item>> GetItems();
        Task<int> GetCount();
        Task<double> GetTotalCost();
        Task MigrateCart(Guid id);
    }
}
