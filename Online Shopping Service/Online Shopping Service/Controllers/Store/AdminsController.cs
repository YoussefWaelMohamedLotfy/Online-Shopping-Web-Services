﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;
using Online_Shopping_Service.Persistence;
using Online_Shopping_Service.Core;

namespace Online_Shopping_Service.Controllers.Store
{
    public class AdminsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public AdminsController()
        {
            _context = new ApplicationDbContext();
        }

        public AdminsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Admins/GetItems
        [System.Web.Http.HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = _context.Items.ToList();
            return items;
        }

        // GET: /Admins/GetItem/1
        [System.Web.Http.HttpGet]
        public ActionResult GetItem(int id)
        {
            var item = _context.Items.SingleOrDefault(c => c.ID == id);

            if (item == null)
                return HttpNotFound();

            return View();
        }


    }
}