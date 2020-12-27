﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;
using Online_Shopping_Service.ViewModels;

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

            var cartViewModel = new CartViewModel
            {
                CartItems = items,
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
    }
}