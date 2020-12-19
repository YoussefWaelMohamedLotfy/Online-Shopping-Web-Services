//using System;
//using System.Linq;
//using System.Security.Claims;
//using System.Web.Http;
//using Microsoft.AspNet.Identity;
//using Online_Shopping_Service.DTOs;
//using Online_Shopping_Service.Models;
//using Online_Shopping_Service.Models.Store;
//using Online_Shopping_Service.Persistence;

//namespace Online_Shopping_Service.Controllers.APIs
//{
//    public class UserController : ApiController
//    {
//        private readonly ApplicationDbContext _context;

//        public UserController()
//        {
//            _context = new ApplicationDbContext();
//        }

//        // GET: /api/User/GetItem/1
//        [HttpGet]
//        public IHttpActionResult GetItem(int id)
//        {
//            var item = _context.Items.SingleOrDefault(c => c.ID == id);

//            if (item == null)
//                return NotFound();

//            return Ok(StoreMapper.mapper.Map<Item, ItemDto>(item));
//        }

//        // POST: /api/User/AddToCart/1
//        [HttpGet]
//        public IHttpActionResult AddToCart(int id)
//        {
//            var item = _context.Items.SingleOrDefault(c => c.ID == id);

//            if (item == null)
//                return NotFound();

//            //CartItem cartItem = new CartItem
//            //{
//            //    ID = id,
//            //    Item = item,
//            //    Count = 1
//            //};
//            var email = User.Identity.GetUserName();
//            var otherItemsCount = _context.CartItems.Where(c => c.UserEmail == email).Count();

//            if (otherItemsCount == 0)
//            {
//                OrderCart orderCart = new OrderCart
//                {
//                    UserEmail = email,
//                    PurchaseDate = DateTime.Now
//                };
//                _context.OrderCart.Add(orderCart);
//            }

//            _context.CartItems.Add(new CartItem
//            {
//                ItemID = id,
//                UserEmail = email ?? "",
//                Count = 1,
//                //Cart = 
//            });

//            _context.SaveChanges();

//            return Created(new Uri(Request.RequestUri + "/" + item.ID), item);
//        }

//        private ApplicationUser GetCurrentUser(ApplicationDbContext context)
//        {
//            var identity = User.Identity as ClaimsIdentity;
//            Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

//            return context.Users.FirstOrDefault(u => u.Id == identityClaim.Value);
//        }
//    }
//}
