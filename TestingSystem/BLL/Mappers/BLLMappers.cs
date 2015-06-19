using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class BLLMappers
    {
        public static BLLRole ToBllRole(this DALRole role)
        {
            return new BLLRole()
            {
                Description = role.Description,
                Id = role.Id,
                Name = role.Name
            };
        }
        public static DALRole ToDalRole(this BLLRole role)
        {
            return new DALRole()
            {
                Description = role.Description,
                Id = role.Id,
                Name = role.Name
            };
        }
        public static BLLUser ToBllUser(this DALUser user)
        {
            return new BLLUser()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }
        public static DALUser ToDalUser(this BLLUser user)
        {
            return new DALUser()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }
        public static BLLTest ToBllTest(this DALTest test)
        {
            return new BLLTest()
            {
                Duration = test.Duration,
                Id = test.Id,
                Name = test.Name
            };
        }
        public static DALTest ToDalTest(this BLLTest test)
        {
            return new DALTest()
            {
                Duration = test.Duration,
                Id = test.Id,
                Name = test.Name
            };
        }
        public static BLLQuestion ToBllQuestion(this DALQuestion q)
        {
            return new BLLQuestion()
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                TestId = q.TestId
            };
        }
        public static DALQuestion ToDalQuestion(this BLLQuestion q)
        {
            return new DALQuestion()
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                TestId = q.TestId
            };
        }
        public static BLLAnswer ToBllAnswer(this DALAnswer answer)
        {
            return new BLLAnswer()
            {
                AnswerText = answer.AnswerText,
                Id = answer.Id,
                IsRight = answer.IsRight,
                QuestionId = answer.QuestionId
            };
        }
        public static DALAnswer ToDalAnswer(this BLLAnswer answer)
        {
            return new DALAnswer()
            {
                AnswerText = answer.AnswerText,
                Id = answer.Id,
                IsRight = answer.IsRight,
                QuestionId = answer.QuestionId
            };
        }
        public static BLLGivenAnswer ToBllGivenAnswer(this DALGivenAnswer ga)
        {
            return new BLLGivenAnswer()
            {
                AnswerId = ga.AnswerId,
                Id = ga.Id,
                TestResultId = ga.TestResultId
            };
        }
        public static DALGivenAnswer ToDalGivenAnswer(this BLLGivenAnswer ga)
        {
            return new DALGivenAnswer()
            {
                AnswerId = ga.AnswerId,
                Id = ga.Id,
                TestResultId = ga.TestResultId
            };
        }
        public static BLLTestResult ToBllTestResult(this DALTestResult tr)
        {
            return new BLLTestResult()
            {
                FinishTime = tr.FinishTime,
                Id = tr.Id,
                Result = tr.Result,
                StartTime = tr.StartTime,
                TestId = tr.TestId,
                UserId = tr.UserId
            };
        }
        public static DALTestResult ToDalTestResult(this BLLTestResult tr)
        {
            return new DALTestResult()
            {
                FinishTime = tr.FinishTime,
                Id = tr.Id,
                Result = tr.Result,
                StartTime = tr.StartTime,
                TestId = tr.TestId,
                UserId = tr.UserId
            };
        }


        public static DALUser ToDalUserFull(this BLLUser user)
        {
            var newUser = ToDalUser(user);
            newUser.Role = ToDalRole(user.Role);
            return newUser;
        }
        public static BLLUser ToBllUserFull(this DALUser user)
        {
            var newUser = ToBllUser(user);
            newUser.Role = ToBllRole(user.Role);
            foreach (var tr in user.TestResults)
                newUser.TestResults.Add(tr.ToBllTestResultFull());
            return newUser;
        }
        public static BLLRole ToBllRoleFull(this DALRole role)
        {
            var newRole = role.ToBllRole();
            foreach (var us in role.Users)
                newRole.Users.Add(us.ToBllUser());
            return newRole;
        }
        public static BLLAnswer ToBllAnswerFull(this DALAnswer answer)
        {
            var newAnswer = answer.ToBllAnswer();
            newAnswer.Question = answer.Question.ToBllQuestion();
            return newAnswer;
        }
        public static DALAnswer ToDalAnswerFull(this BLLAnswer answer)
        {
            var newAnswer = answer.ToDalAnswer();
            newAnswer.Question = answer.Question.ToDalQuestion();
            return newAnswer;
        }
        public static BLLGivenAnswer ToBllGivenAnswerFull(this DALGivenAnswer ga)
        {
            var newGA = ga.ToBllGivenAnswer();
            newGA.Answer = ga.Answer.ToBllAnswer();
            newGA.TestResult = ga.TestResult.ToBllTestResult();
            return newGA;
        }
        public static DALGivenAnswer ToDalGivenAnswerFull(this BLLGivenAnswer ga)
        {
            var newGA = ga.ToDalGivenAnswer();
            newGA.Answer = ga.Answer.ToDalAnswer();
            newGA.TestResult = ga.TestResult.ToDalTestResult();
            return newGA;
        }
        public static BLLQuestion ToBllQuestionFull(this DALQuestion q)
        {
            var newQ = q.ToBllQuestion();
            newQ.Test = q.Test.ToBllTest();
            foreach (var a in q.Answers)
                newQ.Answers.Add(a.ToBllAnswer());
            return newQ;
        }
        public static DALQuestion ToDalQuestionFull(this BLLQuestion q)
        {
            var newQ = q.ToDalQuestion();
            foreach (var a in q.Answers)
                newQ.Answers.Add(a.ToDalAnswer());
            return newQ;
        }
        public static BLLTest ToBllTestFull(this DALTest test)
        {
            var newTest = test.ToBllTest();
            foreach (var q in test.Questions)
                newTest.Questions.Add(q.ToBllQuestionFull());
            foreach (var t in test.TestResults)
                newTest.TestResults.Add(t.ToBllTestResult());
            return newTest;
        }
        public static DALTest ToDalTestFull(this BLLTest test)
        {
            var newTest = test.ToDalTest();
            foreach (var q in test.Questions)
                newTest.Questions.Add(q.ToDalQuestionFull());
            return newTest;
        }
        public static BLLTestResult ToBllTestResultFull(this DALTestResult tr)
        {
            var newTR = tr.ToBllTestResult();
            newTR.User = tr.User.ToBllUser();
            newTR.Test = tr.Test.ToBllTestFull();
            foreach (var ga in tr.GivenAnswers)
                newTR.GivenAnswers.Add(ga.ToBllGivenAnswerFull());
            return newTR;
        }
        public static DALTestResult ToDalTestResultFull(this BLLTestResult tr)
        {
            var newTR = tr.ToDalTestResult();
            foreach (var ga in tr.GivenAnswers)
                newTR.GivenAnswers.Add(ga.ToDalGivenAnswer());
            return newTR;
        }
    }
}
