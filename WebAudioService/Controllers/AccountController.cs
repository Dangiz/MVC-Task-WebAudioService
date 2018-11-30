using System;
using System.Web.Mvc;
using System.Web.Security;
using WebAudioService.DataAccessContracts;
using WebAudioService.Entities;
using WebAudioService.ListDataAccess;

namespace WebAudioService.Controllers
{
    public class AccountController : Controller
    {
        IUserDao users = new CollectionUserRepo();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User userFromRepo = users.GetUserByName(user.Name);
                if (userFromRepo == null || !userFromRepo.Password.Equals(user.Password))
                {
                    ModelState.AddModelError("Name", "Username or password mismatch");

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.Name, true);
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(user);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (users.IsNameUnique(user.Name))
                {
                    users.Insert(user);
                }
                else
                {
                    ModelState.AddModelError("Name", new Exception("User with this name already exist"));
                }
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}