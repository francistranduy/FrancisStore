using FrancisStore.Service.Products.Interfaces;
using FrancisStore.Service.Products.Models;
using FrancisStore.Service.Services;
using FrancisStore.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICollectionService _collectionService;


        private IProductService ProductService
        {
            get
            {
                return _productService;
            }
        }
        private ICollectionService CollectionService
        {
            get
            {
                return _collectionService;
            }
        }

        public ProductController(IProductService productService, ICollectionService collectionService)
        {
            _productService = productService;
            _collectionService = collectionService;
        }

        public async Task<ActionResult> Index(long? Id, string searchString, int page = 1, int pageSize = 9)
        {
            var products = default(IList<Product>);
            int num = 0;

            if (Id != null)
            {
                products = await ProductService.GetPagedProductListByCollectionIdAsync(Id.Value, searchString, page, pageSize);
                num = await ProductService.CountByCollectionIdAsync(Id.Value, searchString);
            }
            else
            {
                products = await ProductService.GetPagedProductListAsync(searchString, page, pageSize);
                num = await ProductService.CountAsync(searchString);
            }

            var collections = await CollectionService.GetCollectionsAsync(pageSize: 6);
            var collectionsVM = collections.Select(c => new CollectionViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            var pagedListVM = new PagedListViewModel
            {
                Page = page,
                PageSize = pageSize,
                Search = searchString,
                From = (page - 1) * pageSize + 1,
                To = (page * pageSize < num) ? page * pageSize : num,
                Total = num
            };

            var productsVM = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Price = p.Price,
                VariantId = p.DefaultVariant,
            });

            if (RouteData.Values.ContainsKey("Id"))
                RouteData.Values.Remove("Id");
            return View(new PagedProductListViewModel { PagedList = pagedListVM, Products = productsVM, Collections = collectionsVM });
        }

        public async Task<ActionResult> Details(ProductDetailsViewModel productdetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await ProductService.GetProductDetailsAsync(productdetailsViewModel.Id);
                if (product != null)
                {
                    productdetailsViewModel = new ProductDetailsViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Note = product.Note,
                        Tags = product.Tags,
                        Description = product.Description,
                        AdditionalInformation = product.AdditionalInformation,
                        Images = product.Images.Take(4).ToList(),
                        Properties = product.Options.Keys.ToList(),
                        Options = product.Options,
                        RelatedProduct = product.RelatedProduct?.Select(r => new ProductViewModel
                        {
                            Id = r.Id,
                            Image = r.Image,
                            Name = r.Name,
                            Price = r.Price
                        }).ToList()
                    };

                    if (RouteData.Values.ContainsKey("Id"))
                        RouteData.Values.Remove("Id");
                    return View(productdetailsViewModel);
                }
            }

            return RedirectToActionPermanent(nameof(ProductController.Index));
        }

        public async Task<ActionResult> GetVariantByProductIdAndOptions(long id, IDictionary<string, string> options)
        {
            var variant = await ProductService.GetVariantsByProductIdAndOptions(id , options);

            if (variant is null)
                return HttpNotFound();

            var variantVM = new VariantViewModel
            {
                Id = variant.Id,
                Title = variant.Title,
                Price = variant.Price,
                Position = variant.Position,
                SKU = variant.SKU,
                Options = variant.Options
            };

            return Json(variantVM, JsonRequestBehavior.AllowGet);
        }

        #region ProductPartialView
        [ChildActionOnly]
        public ActionResult Filters()
        {
            return PartialView("_Filters");
        }

        [ChildActionOnly]
        public ActionResult Sorting()
        {
            return PartialView("_Sorting");
        }

        [ChildActionOnly]
        public ActionResult BreadCrumb()
        {
            return PartialView("_BreadCrumb");
        }
        #endregion
    }
}