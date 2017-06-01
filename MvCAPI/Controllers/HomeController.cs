using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbService;

namespace MvCAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyFakeDbService _db;
        public HomeController()
        {
            this._db = new MyFakeDbService();
        }
        // GET: Home
        public ActionResult Index()
        {
            var users = _db.ApprovedUsers.ToList();
            return View(users);
        }

        [HttpPost]
        public ActionResult Delete(string email)
        {
            if (email?.Length > 0)
            {
                _db.RemoveUser(email);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Email, FirstName, LastName")]ApprovedUser user)
        {
            if (ModelState.IsValid)
            {
                if (!_db.UserExists(user))
                {
                    _db.AddUser(user);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("","A user with that email already exists");
            }
            return View();
        }
    }
}