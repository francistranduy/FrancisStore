using FrancisStore.Repository.UnitOfWorks;
using FrancisStore.Service.Products.Interfaces;
using FrancisStore.Service.Products.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = FrancisStore.Data.Entities.Products;

namespace FrancisStore.Service.Products.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectionService(IUnitOfWork unitOfWork)
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

        public async Task<IList<Collection>> GetCollectionsAsync(string searchString = null, int page = 1, int pageSize = 12)
        {
            var collections = SearchCollectionsByName(UnitOfWork.CollectionRepository.GetAll(), searchString).OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize);
            return await collections.OrderBy(c => c.Id).Select(p => new Collection
            {
                Id = p.Id,
                Name = p.Name,
            }).ToListAsync();
        }


        private IQueryable<Entities.Collection> SearchCollectionsByName(IQueryable<Entities.Collection> productCollection, string searchString)
        {
            return string.IsNullOrEmpty(searchString) ? productCollection : productCollection.Where(p => p.Name.Contains(searchString));
        }
    }
}
