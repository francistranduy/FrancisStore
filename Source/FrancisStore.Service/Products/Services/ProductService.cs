using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FrancisStore.Repository.UnitOfWorks;
using FrancisStore.Service.Products;
using FrancisStore.Service.Products.Interfaces;
using FrancisStore.Service.Products.Models;
using Entities = FrancisStore.Data.Entities.Products;

namespace FrancisStore.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Product>> GetPagedProductListAsync(string searchString = null, int page = 1, int pageSize = 50)
        {
            var products = UnitOfWork.ProductRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
                products = products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()));

            return await products.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize).Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Images.FirstOrDefault().Image.Source,
                Price = p.Variants.Any() ? p.Variants.FirstOrDefault().Price : default,
                DefaultVariant = p.Variants.Any() ? p.Variants.FirstOrDefault().Id : default
            }).ToListAsync();
        }

        public async Task<int> CountAsync(string searchString = null)
        {
            var products = UnitOfWork.ProductRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
                products = products.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()));

            return await products.CountAsync();
        }

        public async Task<IList<Product>> GetPagedProductListByCollectionIdAsync(long id, string searchString = null, int page = 1, int pageSize = 50)
        {
            var collects = UnitOfWork.CollectRepository.GetAll().Where(c => c.CollectionId == id);
            if (!string.IsNullOrEmpty(searchString))
                collects = collects.Where(c => c.Product.Name.ToUpper().Contains(searchString.ToUpper()));

            return await collects.OrderBy(c => c.Product.Name).Skip((page - 1) * pageSize).Take(pageSize).Select(c => new Product
            {
                Id = c.Product.Id,
                Name = c.Product.Name,
                Image = c.Product.Images.FirstOrDefault().Image.Source,
                Price = c.Product.Variants.Any() ? c.Product.Variants.FirstOrDefault().Price : default
            }).ToListAsync();
        }

        public async Task<int> CountByCollectionIdAsync(long id, string searchString = null)
        {
            var collects = UnitOfWork.CollectRepository.GetAll().Where(c => c.CollectionId == id);
            if (!string.IsNullOrEmpty(searchString))
                collects = collects.Where(c => c.Product.Name.ToUpper().Contains(searchString.ToUpper()));

            return await collects.CountAsync();
        }

        public async Task<ProductDetails> GetProductDetailsAsync(long id)
        {
            var product = await UnitOfWork.ProductRepository.GetById(id);
            if (product is null)
                return default;

            return new ProductDetails
            {
                Id = product.Id,
                Name = product.Name,
                Price = GetProductPrice(product),
                Note = product.Note,
                Tags = product.Tags,
                Description = product.Description,
                AdditionalInformation = product.AdditionalInformation,
                Images = GetProductImages(product),
                Options = GetProductOptions(product),
                RelatedProduct = GetRelatedProducts(product)
            };
        }

        public async Task<Variant> GetVariantsByProductIdAndOptions(long id, IDictionary<string, string> options)
        {
            var product = await UnitOfWork.ProductRepository.GetById(id);
            if (product is null)
                return default;

            return GetVariantByProductAndOptions(product, options);
        }

        #region [Private Method]

        private Variant GetVariantByProductAndOptions(Entities.Product product, IDictionary<string, string> options)
        {
            if (product is null || options is null)
                throw new ArgumentNullException();

            //There are no variants of this product
            if (!product.Variants.Any())
                return default;

            //There are no other options of this product
            if (options.Count() != product.Variants.FirstOrDefault().Options.Count())
                return default;

            //Get all variants
            var variants = product.Variants.ToList();

            //Filter variants by options
            foreach (var property in options.Keys.ToList())
            {
                variants = variants.Where(v => v.Options.Any(o => o.Property.Name == property && o.Value == options[property])).ToList();

                //There are no variants meet requirement
                if (!variants.Any())
                    return default;
            }

            //Get first variant if there are many variants which meet requirement
            var variant = variants.FirstOrDefault();

            //Return variant which meet requirement
            return new Variant
            {
                Id = variant.Id,
                Title = variant.Title,
                Price = variant.Price,
                SKU = variant.SKU,
                Position = variant.Position,
                Options = variant.Options.ToDictionary(o => o.Property.Name, o => o.Value)
            };
        }

        private IList<Product> GetRelatedProducts(Entities.Product product)
        {
            if (product is null)
                throw new ArgumentNullException();

            if (!product.Collects.Any())
                return new List<Product>();

            return product.Collects.OrderBy(c => c.Position).FirstOrDefault().Collection.Collects
                .Where(c => c.ProductId != product.Id)
                .Select(c => new Product
                {
                    Id = c.Product.Id,
                    Name = c.Product.Name,
                    Image = c.Product.Images?.FirstOrDefault().Image.Source,
                    Price = GetProductPrice(c.Product)
                })
                .ToList();
        }

        private IDictionary<string, IList<string>> GetProductOptions(Entities.Product product)
        {
            if (product is null)
                throw new ArgumentNullException();

            var options = new Dictionary<string, IList<string>>();
            if (!product.Variants.Any())
                return options;

            foreach (var property in product.Variants.FirstOrDefault().Options.OrderBy(o => o.PropertyId).Select(o => o.Property.Name))
            {
                options.Add(property, product.Variants.Select(v => v.Options.Where(o => o.Property.Name == property).FirstOrDefault()?.Value + string.Empty).Distinct().ToList());
            }
            return options;
        }

        private double GetProductPrice(Entities.Product product)
        {
            if (product is null)
                throw new ArgumentNullException();

            return product.Variants.Any() ? product.Variants.OrderBy(v => v.Position).FirstOrDefault().Price : default;
        }
        private IList<string> GetProductImages(Entities.Product product)
        {
            if (product is null)
                throw new ArgumentNullException();

            return product.Images.Select(i => i.Image.Source).ToList();
        }
        #endregion
    }
}
