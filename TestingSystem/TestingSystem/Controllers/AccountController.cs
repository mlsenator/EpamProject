using TestingSystem.Models;
using TestingSystem.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using BLL.Interface.Entities;


namespace TestingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRoleService service;
        public AccountController(IRoleService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Session["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogOnViewModel model)
        {
            string returnUrl = (string)Session["ReturnUrl"];
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                    if (returnUrl != null)
                        return Redirect(returnUrl);
                    else return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var user = new BLLUser()
                {
                    Name = rvm.Login,
                    Email = rvm.Email,
                    Password = rvm.Password,
                    RoleId = 3
                };

                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(user);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(rvm.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Registration error.");
                }
            }
            return View(rvm);
        }

    }
}