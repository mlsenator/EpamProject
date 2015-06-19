using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using BLL.Interface;
using Microsoft.AspNet.Identity;

namespace TestingSystem.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ITestService service;
        private readonly ITestHelper testHelper;
        private readonly ITestResultService testResultService;
        public TestController(ITestService service, ITestHelper testHelper, ITestResultService testResultService)
        {
            this.service = service;
            this.testHelper = testHelper;
            this.testResultService = testResultService;
        }
        // GET: Test

        public ActionResult StartTest(int id)
        {
            var test = service.GetById(id);
            Session["start_time"] = DateTime.Now;
            return View(test);
        }
        [HttpPost]
        public ActionResult StartTest(FormCollection collection)
        {
            var finishTime = DateTime.Now;
            var startTime = (DateTime)Session["start_time"];
            int testId = Convert.ToInt32(collection["Id"]);
            var test = service.GetById(testId);
            List<int> answersId = new List<int>();
            foreach (var q in test.Questions)
            {
                if (q.NumOfRightAnswers == 1)
                {
                    var id = Convert.ToInt32(collection[q.Id.ToString()]);
                    if (id != 0)
                        answersId.Add(id);
                }    
                else
                {
                    foreach (var answ in q.Answers)
                    {
                        if (collection[answ.Id.ToString()].Contains("true"))
                            answersId.Add(answ.Id);
                    }
                } 
            }
            var testResultId = testHelper.HandleTestResult(test, answersId, User.Identity.GetUserName(), startTime, finishTime);
            
            return RedirectToAction("TestResult", new { id = testResultId });
        }
        [AllowAnonymous]
        public ActionResult TestInfo(int id)
        {
            return View(service.GetById(id));
        }

        public ActionResult TestResult(int id)
        {
            var testResult = testResultService.GetById(id);
            return View(testResult);
        }

        public ActionResult TestResultDetails(int testResultId)
        {
            var testResult = testResultService.GetById(testResultId);

            return View(testResult);
        }

    }
}