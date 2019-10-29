using FrancisStore.Identity;
using FrancisStore.Service.Checkout.Interfaces;
using FrancisStore.Service.Checkout.Models;
using FrancisStore.Service.Shopping.Interfaces;
using FrancisStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IShoppingCartService _shoppingcartService;
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(IShoppingCartService shoppingcartService, ICheckoutService checkoutService)
        {
            _shoppingcartService = shoppingcartService;
            _checkoutService = checkoutService;
        }

        private IShoppingCartService ShoppingCartService
        {
            get
            {
                return _shoppingcartService;
            }
        }
        private ICheckoutService CheckoutService
        {
            get
            {
                return _checkoutService;
            }
        }
        // GET: Checkout

        public async Task<ActionResult> Index(long? country)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToActionPermanent("Login", "Account");

            var selectedCountry = country.GetValueOrDefault();
            var countries = await ShoppingCartService.GetCountries();
            var model = new CheckoutViewModel
            {
                Country = selectedCountry,
                Countries = countries.Select(c => new CountryViewModel { Id = c.Id, Name = c.Name, ShippingFee = c.ShippingFee, IsSelected = c.Id == selectedCountry })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(CheckoutViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToActionPermanent("Login", "Account");

            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    PostalCode = model.PostalCode,
                    Phone = model.Phone,
                    Email = model.Email,
                    OrderDate = ControllerContext.HttpContext.Timestamp,
                    CountryId = model.Country,
                    UserId = Guid.Parse(User.Identity.GetUserId())
                };
                var orderId = await CheckoutService.AddOrder(order);
                return RedirectToActionPermanent(nameof(CheckoutController.Complete), new { id = orderId });
            }

            var countries = await ShoppingCartService.GetCountries();
            model.Countries = countries.Select(c => new CountryViewModel { Id = c.Id, Name = c.Name, ShippingFee = c.ShippingFee, IsSelected = c.Id == model.Country });
            return View(model);
        }

        public ActionResult Complete(long id)
        {
            return View(id);
        }
    }
}