using ENOCA.NET_CHALLENGE.Identity;
using ENOCA.NET_CHALLENGE.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENOCA.NET_CHALLENGE.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AplicationUser> UserManager;
        private RoleManager<AplicationRole> RoleManager;

        public AccountController()
        {
            var userStore= new UserStore<AplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<AplicationUser>(userStore);
            var roleStore = new RoleStore<AplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<AplicationRole>(roleStore);

        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (!ModelState.IsValid)
            { 
                var user = new AplicationUser();
                user.Name = model.Name;
                user.Email = model.Email;
                user.Surname= model.Surname;
                user.UserName= model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("User"))
                    {
                        UserManager.AddToRole(user.Id, "User");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "User Creation Error");
                }

            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {

                    var authManager=HttpContext.GetOwinContext().Authentication;

                    var identityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties();

                    authProperties.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProperties,identityClaims);

                    if(!String.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);

                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "User does not exist");
                }

            }

            return View();
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}