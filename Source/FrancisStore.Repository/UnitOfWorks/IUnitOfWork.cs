﻿using FrancisStore.Repository.Bases;
using FrancisStore.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenericRepository<FrancisStore.Data.Entities.Products.Product> ProductRepository { get; }
        IGenericRepository<FrancisStore.Data.Entities.Products.Collection> CollectionRepository { get; }
        IGenericRepository<FrancisStore.Data.Entities.Products.Collect> CollectRepository { get; }
        IGenericRepository<FrancisStore.Data.Entities.Products.Variant> VariantRepository { get; }
        IGenericRepository<FrancisStore.Data.Entities.Shopping.Item> ItemRepository { get; }
        IGenericRepository<FrancisStore.Data.Entities.Checkout.Country> CountryRepository { get; }
        IGenericRepository<FrancisStore.Data.Entities.Checkout.Order> OrderRepository { get; }
        IGenericRepository<FrancisStore.Data.Entities.Checkout.OrderDetail> OrderDetailRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
