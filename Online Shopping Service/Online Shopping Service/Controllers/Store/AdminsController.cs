using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;
using Online_Shopping_Service.Persistence;
using Online_Shopping_Service.Core;
using Online_Shopping_Service.ViewModels;

namespace Online_Shopping_Service.Controllers.Store
{
    public class AdminsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext context;

        public AdminsController()
        {
            context = new ApplicationDbContext();
        }

        public AdminsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Admins
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Admins/CreateItem
        public ActionResult CreateItem()
        {
            var newItemViewModel = new NewItemViewModel
            {
                Item = new Item(),
            };

            return View(newItemViewModel);
        }

        // GET: /Admins/EditItem/2
        public ActionResult EditItem(int id)
        {
            var item = context.Items.SingleOrDefault(c => c.ID == id);

            if (item == null)
                return HttpNotFound();

            var newItemViewModel = new NewItemViewModel
            {
                Item = item,
            };

            return View("CreateItem", newItemViewModel);
        }

        // POST: /Admins/AddNewItem
        [HttpPost]
        public ActionResult AddNewItem(NewItemViewModel viewModel)
        {
            if (viewModel.Item.ID == 0)
                context.Items.Add(viewModel.Item);
            else
            {
                var itemInDb = context.Items.Single(c => c.ID == viewModel.Item.ID);
                Item item = StoreMapper.mapper.Map(viewModel.Item, itemInDb);
            }

            context.SaveChanges();

            return RedirectToAction("ShowStore", "Users");
        }

    }
}