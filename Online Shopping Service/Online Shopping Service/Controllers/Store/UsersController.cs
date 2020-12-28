using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;
using Online_Shopping_Service.ViewModels;
using System;

namespace Online_Shopping_Service.Controllers.Store
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        private string email;

        public UsersController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Users
        public ActionResult Index()
        {
            if (User.IsInRole("IsAdmin"))
                return View("Store");

            return View("StoreReadOnly");
        }

        // GET: /Users/ShowStoreUser
        public ActionResult ShowStoreUser()
        {
            var items = context.Items.ToList();

            var storeViewModel = new StoreViewModel
            {
                Items = items
            };

            return View("Store", storeViewModel);
        }

        // GET: /Users/ShowCart
        public ActionResult ShowCart()
        {
            email = User.Identity.GetUserName();
            var items = context.CartItems.Where(c => c.UserEmail == email && c.IsCheckedOut == false).ToList();
            var cartTotal = context.CartItems.Where(c => c.UserEmail == email && c.IsCheckedOut == false).Select(c => c.Item.Price * c.Count).DefaultIfEmpty(0).Sum();
            var cart = context.OrderCarts.SingleOrDefault(c => c.UserEmail == email && c.IsCheckedOut == false);

            var cartViewModel = new CartViewModel
            {
                CartItems = items,
                Cart = cart,
                CartTotal = cartTotal
            };

            return View("Cart", cartViewModel);
        }

        // GET: /Users/ViewDetails
        public ActionResult ViewDetails(int id)
        {
            var itemInDb = context.Items.SingleOrDefault(c => c.ID == id);

            return View("ViewDetails", itemInDb);
        }

        // GET: /Users/Checkout
        public ActionResult Checkout()
        {
            email = User.Identity.GetUserName();
            var items = context.CartItems.Where(c => c.UserEmail == email && c.IsCheckedOut == false).ToList();
            var userCart = context.OrderCarts.SingleOrDefault(c => c.UserEmail == email && c.IsCheckedOut == false);
            var cartTotal = context.CartItems.Where(c => c.UserEmail == email && c.IsCheckedOut == false).Select(c => c.Item.Price * c.Count).DefaultIfEmpty(0).Sum();
            var user = context.Users.Single(c => c.Email == email);

            var checkoutViewModel = new CheckoutViewModel
            {
                Cart = userCart,
                CartItems = items,
                CartTotal = cartTotal,
                CurrentUser = user
            };

            return View(checkoutViewModel);
        }

        // GET: /Users/ConfirmOrder
        public ActionResult ConfirmOrder(int cartID, string method)
        {
            email = User.Identity.GetUserName();
            var cart = context.OrderCarts.SingleOrDefault(c => c.CartID == cartID && c.UserEmail == email && c.IsCheckedOut == false);

            if (cart == null)
                return HttpNotFound();
            else
            {
                cart.IsCheckedOut = true;
                cart.PurchaseDate = DateTime.Now;
                cart.ArrivalDate = DateTime.Now.AddDays(3);
                cart.PaymentMethod = method;
            }

            var cartItems = context.CartItems.Where(c => c.CartID == cartID && c.UserEmail == email).ToList();

            foreach (var item in cartItems)
            {
                item.IsCheckedOut = true;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}