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
        private readonly Guid _id;

        public ShoppingCartService(IUnitOfWork unitOfWork, Guid id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        protected Guid Id
        {
            get
            {
                return _id;
            }
        }

        public async Task AddToCart(Variant variant)
        {
            var item = await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == Id && i.VariantId == variant.Id).FirstOrDefaultAsync();

            if (item is null)
            {
                //Create new item if there is no item in cart
                UnitOfWork.ItemRepository.Insert(new FrancisStore.Data.Entities.Shopping.Item
                {
                    VariantId = variant.Id,
                    ShoppingCartId = Id,
                    Count = 1,
                    DateCreated = DateTime.Now
                });
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                item.Count++;
            }

            await UnitOfWork.SaveAsync();
            return;
        }

        public async Task<int> RemoveItem(long itemId)
        {
            var item = await UnitOfWork.ItemRepository.GetAll().Where(i => i.Id == itemId && i.ShoppingCartId == Id).FirstOrDefaultAsync();

            if (item is null || item.Count < 1)
                return default;

            if (item.Count > 1)
                item.Count--;
            else
                UnitOfWork.ItemRepository.Delete(item);
            await UnitOfWork.SaveAsync();
            return item.Count;
        }

        public async Task Clear()
        {
            var items = UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == Id);

            foreach(var item in items)
            {
                UnitOfWork.ItemRepository.Delete(item);
            }
            await UnitOfWork.SaveAsync();
            return;
        }

        public async Task<int> GetCount()
        {
            return await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == Id).Select(i => i.Count).SumAsync();
        }

        public async Task<IList<Item>> GetItems()
        {
            return await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == Id).Select(i => new Item
            {
                Id = i.Id,
                Name = i.Variant.Title,
                Properties = i.Variant.Options.ToDictionary(o => o.Property.Name, o => o.Value),
                Count = i.Count,
                DateCreated = i.DateCreated
            }).ToListAsync();
        }

        public async Task<double> GetTotalCost()
        {
            return await UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == Id).Select(i => i.Variant.Price * i.Count).SumAsync();
        }

        public async Task MigrateCart(Guid id)
        {
            var items = UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == Id);

            foreach (var item in items)
            {
                item.ShoppingCartId = id;
            }
            await UnitOfWork.SaveAsync();
            return;
        }
    }
}
