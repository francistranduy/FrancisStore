using FrancisStore.Data;
using FrancisStore.Data.Entities.Products;
using FrancisStore.Data.Entities.Shopping;
using FrancisStore.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IFrancisStoreDbContext _context;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Collection> _collectionRepository;
        private readonly IGenericRepository<Collect> _collectRepository;
        private readonly IGenericRepository<Item> _itemRepository;

        public UnitOfWork(IFrancisStoreDbContext context, IGenericRepository<Product> productRepository, IGenericRepository<Collection> collectionRepository, IGenericRepository<Collect> collectRepository, IGenericRepository<Item> itemRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _collectionRepository = collectionRepository;
            _collectRepository = collectRepository;
            _itemRepository = itemRepository;
        }

        protected IFrancisStoreDbContext DbContext
        {
            get
            {
                return _context;
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }

        public IGenericRepository<Collection> CollectionRepository
        {
            get
            {
                return _collectionRepository;
            }
        }

        public IGenericRepository<Collect> CollectRepository
        {
            get
            {
                return _collectRepository;
            }
        }
        public IGenericRepository<Item> ItemRepository
        {
            get
            {
                return _itemRepository;
            }
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
