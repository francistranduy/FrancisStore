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
        string SessionKey { get; }
        Task AddToCart(Guid id, long variantId, int count = 1);
        Task<int> RemoveItem(Guid id, long itemId);
        Task Clear(Guid id);
        Task<IList<Item>> GetItems(Guid id);
        Task<int> GetCount(Guid id);
        Task<double> GetTotalCost(Guid id);
        Task MigrateShoppingCart(Guid id, Guid userId);
    }
}
