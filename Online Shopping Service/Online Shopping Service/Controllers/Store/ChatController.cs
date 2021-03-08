using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.Controllers.Store
{
    [Authorize]
    public class ChatController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<ApplicationUser> _userManager;

        public ChatController()
        {
            _context = new ApplicationDbContext();
        }

        public ChatController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Chat
        public ActionResult Index()
        {
            //var currentUser = User.Identity.GetUserName();
            //ViewBag.CurrentUser = currentUser;
            //var messages = await _context.Messages.ToListAsync();
            return View();
        }

        public ActionResult ChatAdvanced()
        {
            return View();
        }

        public async Task<ActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                message.UserID = User.Identity.GetUserId();
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}