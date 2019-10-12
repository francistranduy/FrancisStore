using FrancisStore.Data.Entities.Identity;
using FrancisStore.Identity;
using FrancisStore.Service.Shopping.Interfaces;
using FrancisStore.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingcartService;

        public CartController(IShoppingCartService shoppingcartService)
        {
            _shoppingcartService = shoppingcartService;
        }
        private IShoppingCartService ShoppingCartService
        {
            get
            {
                return _shoppingcartService;
            }
        }
        private Guid ShoppingCartId
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                    return Guid.Parse(User.Identity.GetUserId());

                if (Session[ShoppingCartService.SessionKey] is null)
                    Session[ShoppingCartService.SessionKey] = Guid.NewGuid();

                return (Guid)Session[ShoppingCartService.SessionKey];
            }
        }

        // GET: Cart
        public async Task<ActionResult> Index()
        {
            var items = await ShoppingCartService.GetItems(this.ShoppingCartId);
            return View(new ItemListViewModel
            {
                Items = items.Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Image = i.Image,
                    Options = i.Options.Select(o => string.Concat(o.Key.ToUpper(), ": ", o.Value)).Aggregate(string.Empty, (accumulate, next) => (accumulate == string.Empty ? accumulate : accumulate + ", ") + next),
                    Price = i.Price,
                    Count = i.Count,
                    Total = i.Count * i.Price
                }), 
                Subtatol = items.Select(i => i.Price * i.Count).Sum()
            });
        }

        public async Task<ActionResult> AddToCart(long variantId, int quantity = 1)
        {
            if (!Request.IsAjaxRequest())
                return HttpNotFound();

            await ShoppingCartService.AddToCart(ShoppingCartId, variantId, quantity);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public async Task<ActionResult> Clear()
        {
            if (!Request.IsAjaxRequest())
                return HttpNotFound();

            await ShoppingCartService.Clear(ShoppingCartId);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [ChildActionOnly]
        public ActionResult Notification()
        {
            var items = Task.Run(() => ShoppingCartService.GetItems(this.ShoppingCartId)).Result;
            return PartialView("_Notification", new ItemListViewModel
            {
                Items = items.Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Image = i.Image,
                    Options = i.Options.Select(o => string.Concat(o.Key.ToUpper(), ": ", o.Value)).Aggregate(string.Empty, (accumulate, next) => (accumulate == string.Empty ? accumulate : accumulate + ", ") + next),
                    Price = i.Price,
                    Count = i.Count,
                    Total = i.Count * i.Price
                }),
                Subtatol = items.Select(i => i.Price * i.Count).Sum()
            });
        }
    }
}