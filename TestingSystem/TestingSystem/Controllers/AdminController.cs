using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace TestingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public AdminController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users()
        {
            var users = userService.GetAll();
            return View(users);
        }
        public ActionResult EditUser(int id)
        {
            var user = userService.GetById(id);
            ViewBag.RoleId = new SelectList(roleService.GetAll(), "Id", "Name", user.RoleId);

            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(BLLUser user)
        {
            var editedUser = userService.GetById(user.Id);
            editedUser.RoleId = user.RoleId;
            userService.Edit(editedUser);

            return RedirectToAction("Users");
        }
        public ActionResult DeleteUser(int id)
        {
            userService.Delete(userService.GetById(id));
            return RedirectToAction("Users");
        }
    }
}