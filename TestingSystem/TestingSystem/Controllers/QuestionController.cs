using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace TestingSystem.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService service;
        public QuestionController(IQuestionService service)
        {
            this.service = service;
        }
        // GET: Question
        public ActionResult Create(int testId)
        {
            return View(new BLLQuestion() { TestId = testId});
        }
        [HttpPost]
        public ActionResult Create(BLLQuestion q)
        {
            if (ModelState.IsValid)
            {
                service.Add(q);
                return RedirectToAction("Edit", "TestManager", new { id = q.TestId});
            }
            return View(q);
        }

        [HttpPost]
        public string CreateAjax(BLLQuestion question)
        {
            service.Add(question);

            return "Question added";
        }

        public ActionResult Edit(int id)
        {
            var q = service.GetById(id);
            return View(q);
        }
        [HttpPost]
        public ActionResult Edit(BLLQuestion q)
        {
            if (ModelState.IsValid)
            {
                service.Edit(q);
                return RedirectToAction("Edit", "TestManager", new { id = q.TestId });
            }
            return View(q);
        }

        public ActionResult Delete(int id)
        {
            var q = service.GetById(id);
            service.Delete(q);
            return RedirectToAction("Edit", "TestManager", new { id = q.TestId});
        }
    }
}