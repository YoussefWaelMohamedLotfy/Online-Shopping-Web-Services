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
        //private readonly string email;

        public UsersController()
        {
            //email = User.Identity.GetUserName();
            context = new ApplicationDbContext();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Users/ShowStore
        public ActionResult ShowStore()
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
            var items = context.CartItems.Where(c => /*c.UserEmail == email &&*/ c.IsCheckedOut == false).ToList();

            var cartViewModel = new CartViewModel
            {
                CartItems = items
            };

            return View("Cart", cartViewModel);
        }
    }
}