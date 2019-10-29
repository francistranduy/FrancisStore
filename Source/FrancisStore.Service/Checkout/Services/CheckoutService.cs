using FrancisStore.Repository.UnitOfWorks;
using FrancisStore.Service.Checkout.Interfaces;
using FrancisStore.Service.Checkout.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Checkout.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public CheckoutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> AddOrder(Order order)
        {
            if (order is null)
                throw new ArgumentNullException();

            var items = UnitOfWork.ItemRepository.GetAll().Where(i => i.ShoppingCartId == order.UserId);
            var country = await UnitOfWork.CountryRepository.GetById(order.CountryId);

            var entity = new FrancisStore.Data.Entities.Checkout.Order()
            {
                FirstName = order.FirstName,
                LastName = order.LastName,
                Address = order.Address,
                City = order.City,
                State = order.State,
                PostalCode = order.PostalCode,
                Phone = order.Phone,
                Email = order.Email,
                CountryId = order.CountryId,
                Date = order.OrderDate,
                Total = items.Select(i => (i.Count * i.Variant.Price)).Sum() + country.ShippingFee,
                UserId = order.UserId.ToString(),
                OrderDetails = new List<Data.Entities.Checkout.OrderDetail>()
            };
            UnitOfWork.OrderRepository.Insert(entity);
            await UnitOfWork.SaveAsync();

            foreach (var item in items)
            {
                entity.OrderDetails.Add(new Data.Entities.Checkout.OrderDetail
                {
                    OrderId = entity.Id,
                    Quantity = item.Count,
                    UnitPrice = item.Variant.Price,
                    VariantId = item.Variant.Id
                });
            }

            foreach (var item in items)
            {
                UnitOfWork.ItemRepository.Delete(item);
            }

            await UnitOfWork.SaveAsync();
            return entity.Id;
        }
    }
}
