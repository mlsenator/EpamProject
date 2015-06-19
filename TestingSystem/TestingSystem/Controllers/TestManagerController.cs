 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace TestingSystem.Controllers
{
    [Authorize(Roles="Admin")]
    public class TestManagerController : Controller
    {
        private readonly ITestService service;
        public TestManagerController(ITestService service)
        {
            this.service = service;
        }
        // GET: TestManager
        public ActionResult Index()
        {
            var tests = service.GetAll();
            return View(tests);
        }

        public ActionResult Details(int id = 1)
        {
            BLLTest test = service.GetById(id);
            if (test == null)
                return HttpNotFound();
            //service.GetAllAnswers(test);
            return View(test);
        }
        public ActionResult Edit(int id = 1)
        {
            var test = service.GetById(id);
            return View(test);
        }
        [HttpPost]
        public ActionResult Edit(BLLTest test)
        {
             if (ModelState.IsValid)
            {
                service.Edit(test);
                return RedirectToAction("Index"); 
            }
            return View(test);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BLLTest test)
        {
            if (ModelState.IsValid)
            {
                service.Add(test);
                return RedirectToAction("Index"); 
            }
            return View(test);
        }
        public ActionResult Delete(int id)
        {
            service.Delete(service.GetById(id));
            return RedirectToAction("Index");
        }
    }
}