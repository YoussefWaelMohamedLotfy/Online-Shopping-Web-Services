using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Online_Shopping_Service.DTOs;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;
using Online_Shopping_Service.Persistence;

namespace Online_Shopping_Service.Controllers.APIs
{
    public class AdminController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/Admin/GetItems
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            return Ok(_context.Items.ToList().Select(StoreMapper.mapper.Map<Item, ItemDto>));
        }

        // GET: /api/Admin/GetItem/1
        [HttpGet]
        public IHttpActionResult GetItem(int id)
        {
            var item = _context.Items.SingleOrDefault(c => c.ID == id);

            if (item == null)
                return NotFound();

            return Ok(StoreMapper.mapper.Map<Item, ItemDto>(item));
        }

        // POST: /api/Admin/CreateItem
        [HttpPost]
        public IHttpActionResult CreateItem(ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = StoreMapper.mapper.Map<ItemDto, Item>(itemDto);

            _context.Items.Add(item);
            _context.SaveChanges();

            itemDto.ID = item.ID;

            return Created(new Uri(Request.RequestUri + "/" + itemDto.ID), itemDto);
        }

        // PUT: /api/Admin/UpdateItem/2
        [HttpPut]
        public IHttpActionResult UpdateItem(int id, ItemDto itemDto)
        {
            itemDto.ID = id;

            if (!ModelState.IsValid)
                return BadRequest();

            var itemInDb = _context.Items.SingleOrDefault(c => c.ID == id);

            if (itemInDb == null)
                return NotFound();

            var newItem = StoreMapper.mapper.Map(itemDto, itemInDb);
            newItem.ID = id;
            _context.SaveChanges();

            return Ok(itemDto);
        }

        // DELETE: /api/Admin/DeleteItem/2
        [HttpDelete]
        public IHttpActionResult DeleteItem(int id)
        {
            var itemInDb = _context.Items.SingleOrDefault(c => c.ID == id);

            if (itemInDb == null)
                return NotFound();

            _context.Items.Remove(itemInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
