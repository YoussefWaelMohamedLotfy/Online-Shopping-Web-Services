using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Online_Shopping_Service.DTOs;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;
using Online_Shopping_Service.Persistence;

namespace Online_Shopping_Service.Controllers.APIs
{
    public class UserController : ApiController
    {
        private readonly ApplicationDbContext context;
        private readonly string email;

        public UserController()
        {
            email = User.Identity.GetUserName();
            context = new ApplicationDbContext();
        }

        // GET: /api/User/GetItems
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            return Json(context.Items.ToList().Select(StoreMapper.mapper.Map<Item, ItemDto>));
        }

        // GET: /api/User/ViewCart
        [HttpGet]
        public IHttpActionResult ViewCart()
        {
            var cartItemsInDb = context.CartItems.Where(c => c.IsCheckedOut == false && c.UserEmail == email).ToList().Select(StoreMapper.mapper.Map<CartItem, CartItemDto>);

            if (cartItemsInDb == null)
                return NotFound();

            return Ok(cartItemsInDb);
        }

        // GET: /api/User/AddToCart/1
        [HttpGet]
        public IHttpActionResult AddToCart(int id)
        {
            OrderCart cart = context.OrderCarts.SingleOrDefault(c => c.UserEmail == email && c.IsCheckedOut == false);
            var cartItemsCount = context.CartItems.Where(c => c.UserEmail == email).Count();

            if (cartItemsCount == 0)
            {
                cart = new OrderCart
                {
                    PaymentMethod = "CASH",
                    Total = 0,
                    UserEmail = email,
                    IsCheckedOut = false
                };

                context.OrderCarts.Add(cart);
            }

            CartItem cartItemInDb = context.CartItems.SingleOrDefault(c => c.UserEmail == email && c.ItemID == id && c.IsCheckedOut == false);

            if (cartItemInDb != null)
                cartItemInDb.Count++;
            else
            {
                var cartItem = new CartItem
                {
                    ItemID = id,
                    Count = 1,
                    CartID = cart.CartID,
                    UserEmail = email,
                    IsCheckedOut = false
                };

                context.CartItems.Add(cartItem);
            }

            context.SaveChanges();

            return Ok();
        }

        // GET: /api/User/RemoveFromCart/2
        [HttpGet]
        public IHttpActionResult RemoveFromCart(int id)
        {
            var cartIteminCart = context.CartItems.SingleOrDefault(c => c.UserEmail == email && c.ItemID == id && c.IsCheckedOut == false);

            if (cartIteminCart == null)
                return NotFound();

            context.CartItems.Remove(cartIteminCart);

            var cartItemsCount = context.CartItems.Where(c => c.UserEmail == email && c.IsCheckedOut == false && c.CartID == cartIteminCart.CartID).Count();
            context.SaveChanges();

            if (cartItemsCount - 1 == 0)
            {
                var cart = context.OrderCarts.SingleOrDefault(c => c.UserEmail == email && c.IsCheckedOut == false && c.CartID == cartIteminCart.CartID);
                context.OrderCarts.Remove(cart);
            }

            context.SaveChanges();

            return Ok();
        }

        // GET: /api/User/UpdateCountValueAdd/2
        [HttpGet]
        public IHttpActionResult UpdateCountValueAdd(int id)
        {
            var cartIteminCart = context.CartItems.SingleOrDefault(c => c.UserEmail == email && c.ItemID == id && c.IsCheckedOut == false);

            if (cartIteminCart == null)
                return NotFound();
            else
                cartIteminCart.Count++;

            context.SaveChanges();

            return Ok();
        }

        // GET: /api/User/UpdateCountValueSub/2
        [HttpGet]
        public IHttpActionResult UpdateCountValueSub(int id)
        {
            var cartIteminCart = context.CartItems.SingleOrDefault(c => c.UserEmail == email && c.ItemID == id && c.IsCheckedOut == false);

            if (cartIteminCart == null)
                return NotFound();
            else
                cartIteminCart.Count--;

            context.SaveChanges();

            return Ok();
        }

        // GET: /api/User/ProceedToCheckout
        [HttpGet]
        public IHttpActionResult ProceedToCheckout()
        {
            var cartTotalPrice = context.CartItems.Where(c => c.UserEmail == email && c.IsCheckedOut == false).Select(c => c.Item.Price * c.Count).Sum();
            var cart = context.OrderCarts.SingleOrDefault(c => c.UserEmail == email && c.IsCheckedOut == false);

            if (cart == null)
                return NotFound();
            else
                cart.Total = cartTotalPrice;

            context.SaveChanges();

            return Ok();
        }

        // GET: /api/User/SetDeliveryMethod/CARD
        [HttpGet]
        public IHttpActionResult SetDeliveryMethod(string method)
        {
            var cart = context.OrderCarts.SingleOrDefault(c => c.UserEmail == email && c.IsCheckedOut == false);

            if (cart == null)
                return NotFound();
            else
                cart.PaymentMethod = method;

            context.SaveChanges();

            return Ok();
        }
    }
}