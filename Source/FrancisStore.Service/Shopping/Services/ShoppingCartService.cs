using FrancisStore.Repository.UnitOfWorks;
using FrancisStore.Service.Products.Models;
using FrancisStore.Service.Shopping.Interfaces;
using FrancisStore.Service.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Shopping.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string _sessionKey = "CartId";
        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public async Task AddToCart(Guid id, long variantId, int count = 1)
        {
            var variant = await UnitOfWork.VariantRepository.GetById(variantId);
            if (variant is null)
                return;

            var item = await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == id && i.VariantId == variant.Id).FirstOrDefaultAsync();
            if (item is null)
            {
                //Create new item if there is no item in cart
                UnitOfWork.ItemRepository.Insert(new FrancisStore.Data.Entities.Shopping.Item
                {
                    VariantId = variant.Id,
                    ShoppingCartId = id,
                    Count = count,
                    DateCreated = DateTime.Now
                });
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                item.Count+= count;
            }

            await UnitOfWork.SaveAsync();
            return;
        }

        public async Task<int> RemoveItem(Guid id, long itemId)
        {
            var item = await UnitOfWork.ItemRepository.GetAll().Where(i => i.Id == itemId && i.ShoppingCartId == id).FirstOrDefaultAsync();

            if (item is null || item.Count < 1)
                return default;

            if (item.Count > 1)
                item.Count--;
            else
                UnitOfWork.ItemRepository.Delete(item);
            await UnitOfWork.SaveAsync();
            return item.Count;
        }

        public async Task Clear(Guid id)
        {
            var items = UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == id);

            foreach(var item in items)
            {
                UnitOfWork.ItemRepository.Delete(item);
            }
            await UnitOfWork.SaveAsync();
            return;
        }

        public async Task<int> GetCount(Guid id)
        {
            return await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == id).Select(i => i.Count).SumAsync();
        }

        public async Task<IList<Item>> GetItems(Guid id)
        {
            var items = await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == id).ToListAsync();
                
            return items.Select(i => new Item
            {
                Id = i.Id,
                Image = i.Variant.Product.Images.FirstOrDefault().Image.Source,
                Name = i.Variant.Title,
                Options = i.Variant.Options.ToDictionary(o => o.Property.Name, o => o.Value),
                Price = i.Variant.Price,
                Count = i.Count,
                DateCreated = i.DateCreated
            }).ToList();
        }

        public async Task<double> GetTotalCost(Guid id)
        {
            return await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == id).Select(i => i.Variant.Price * i.Count).SumAsync();
        }

        public async Task<IList<Country>> GetCountries()
        {
            return await UnitOfWork.CountryRepository.GetAll().Select(c => new Country {Id = c.Id, Name = c.Name, ShippingFee = c.ShippingFee }).ToListAsync();
        }

        public async Task MigrateShoppingCart(Guid id, Guid userId)
        {
            var items = UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == id);

            foreach (var item in items)
            {
                item.ShoppingCartId = userId;
            }
            await UnitOfWork.SaveAsync();
            return;
        }

        public async Task<Country> GetCountry(long id)
        {
            var country = await UnitOfWork.CountryRepository.GetById(id);
            if (country is null)
                return default;

            return new Country
            {
                Id = country.Id,
                Name = country.Name,
                ShippingFee = country.ShippingFee
            };
        }

        public string SessionKey
        {
            get
            {
                return _sessionKey;
            }
        }
    }
}
