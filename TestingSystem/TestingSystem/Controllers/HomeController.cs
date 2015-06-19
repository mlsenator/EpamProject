using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace TestingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService service;
        public HomeController(ITestService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            var tests = service.GetAll();

            return View(tests);
        }
    }
}