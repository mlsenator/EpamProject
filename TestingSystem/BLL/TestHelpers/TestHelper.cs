using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface;
using BLL.Interface.Services;

namespace BLL.TestHelpers
{
    public class TestHelper : ITestHelper
    {
        private readonly IAnswerService answerService;
        private readonly IUserService userService;
        private readonly ITestResultService testResultService;
        public TestHelper(IAnswerService answerService, IUserService userService, ITestResultService testResultService)
        {
            this.answerService = answerService;
            this.userService = userService;
            this.testResultService = testResultService;
        }
        public int HandleTestResult(BLLTest test, List<int> answersId, string username, DateTime startTime, DateTime finishTime)
        {
            Dictionary<int, int> givenAnswersDictionary = new Dictionary<int, int>();
            List<BLLAnswer> answers = new List<BLLAnswer>();
            BLLTestResult testResult = new BLLTestResult() { TestId = test.Id };

            foreach (var answerId in answersId)
            {
                answers.Add(answerService.GetById(answerId));
            }
            foreach (var question in test.Questions)
            {
                givenAnswersDictionary.Add(question.Id, question.NumOfRightAnswers);
            }

            foreach (var a in answers)
            {
                if (a.IsRight == true)
                    givenAnswersDictionary[a.QuestionId]--;
                else givenAnswersDictionary[a.QuestionId] = -1;
                testResult.GivenAnswers.Add(new BLLGivenAnswer() { AnswerId = a.Id });
            }

            testResult.Result = 100 * (givenAnswersDictionary.Where(a => a.Value == 0).Count()) / givenAnswersDictionary.Count;
            testResult.UserId = userService.GetAll().Where(u => u.Name == username).First().Id;

            testResult.StartTime = startTime;
            testResult.FinishTime = finishTime;

            var testResultId = testResultService.Add(testResult);
            return testResultId;
        }
    }
}
