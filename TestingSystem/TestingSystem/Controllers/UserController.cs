using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using Microsoft.AspNet.Identity;

namespace TestingSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ITestResultService testResultService;
        private readonly IUserService userService;
        public UserController(ITestResultService testResultService, IUserService userService)
        {
            this.userService = userService;
            this.testResultService = testResultService;
        }
        // GET: User
        public ActionResult Index(string userName = null)
        {
            if (userName == null)
                userName = User.Identity.GetUserName();
            var userId = userService.GetAll().Where(u => u.Name == userName).First().Id;
            var passedTests = testResultService.GetAll().Where(tr => tr.UserId == userId);
            return View(passedTests);
        }
    }
}