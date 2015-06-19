using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Models;

namespace DAL.Mappers
{
    public static class DALMappers
    {
        public static DALRole ToDalRole(this Role role)
        {
            return new DALRole()
            {
                Description = role.Description,
                Id = role.Id,
                Name = role.Name
            };
        }
        public static Role ToOrmRole(this DALRole role)
        {
            return new Role()
            {
                Description = role.Description,
                Id = role.Id,
                Name = role.Name
            };
        }
        public static DALUser ToDalUser(this User user)
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
        public static User ToOrmUser(this DALUser user)
        {
            return new User()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }        
        public static DALTest ToDalTest(this Test test)
        {
            return new DALTest()
            {
                Duration = test.Duration,
                Id = test.Id,
                Name = test.Name
            };
        }
        public static Test ToOrmTest(this DALTest test)
        {
            return new Test()
            {
                Duration = test.Duration,
                Id = test.Id,
                Name = test.Name
            };
        }
        public static DALQuestion ToDalQuestion(this Question q)
        {
            return new DALQuestion()
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                TestId = q.TestId
            };
        }
        public static Question ToOrmQuestion(this DALQuestion q)
        {
            return new Question()
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                TestId = q.TestId
            };
        }
        public static DALAnswer ToDalAnswer(this Answer answer)
        {
            bool bufIsRight = false;
            if (answer.IsRight > 0)
                bufIsRight = true;
            return new DALAnswer()
            {
                AnswerText = answer.AnswerText,
                Id = answer.Id,
                IsRight = bufIsRight,
                QuestionId = answer.QuestionId
            };
        }
        public static Answer ToOrmAnswer(this DALAnswer answer)
        {
            int bufIsRight = 0;
            if (answer.IsRight == true)
                bufIsRight = 1;
            return new Answer()
            {
                AnswerText = answer.AnswerText,
                Id = answer.Id,
                IsRight = bufIsRight,
                QuestionId = answer.QuestionId
            };
        }
        public static DALGivenAnswer ToDalGivenAnswer (this GivenAnswer ga)
        {
            return new DALGivenAnswer()
            {
                AnswerId = ga.AnswerId,
                Id = ga.Id,
                TestResultId = ga.TestResultId
            };
        }
        public static GivenAnswer ToOrmGivenAnswer(this DALGivenAnswer ga)
        {
            return new GivenAnswer()
            {
                AnswerId = ga.AnswerId,
                Id = ga.Id,
                TestResultId = ga.TestResultId
            };
        }
        public static DALTestResult ToDalTestResult(this TestResult tr)
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
        public static TestResult ToOrmTestResult(this DALTestResult tr)
        {
            return new TestResult()
            {
                FinishTime = tr.FinishTime,
                Id = tr.Id,
                Result = tr.Result,
                StartTime = tr.StartTime,
                TestId = tr.TestId,
                UserId = tr.UserId
            };
        }


        public static User ToOrmUserFull(this DALUser user)
        {
            var newUser = ToOrmUser(user);
            newUser.Role = ToOrmRole(user.Role);
            return newUser;
        }
        public static DALUser ToDalUserFull(this User user)
        {
            var newUser = ToDalUser(user);
            newUser.Role = ToDalRole(user.Role);
            foreach (var tr in user.TestResults)
                newUser.TestResults.Add(tr.ToDalTestResultFull());
            return newUser;
        }
        public static DALRole ToDalRoleFull(this Role role)
        {
            var newRole = role.ToDalRole();
            foreach (var us in role.Users)
                newRole.Users.Add(us.ToDalUser());
            return newRole;
        }
        public static DALAnswer ToDalAnswerFull(this Answer answer)
        {
            var newAnswer = answer.ToDalAnswer();
            newAnswer.Question = answer.Question.ToDalQuestion();
            return newAnswer;
        }
        public static Answer ToOrmAnswerFull(this DALAnswer answer)
        {
            var newAnswer = answer.ToOrmAnswer();
            newAnswer.Question = answer.Question.ToOrmQuestion();
            return newAnswer;
        }
        public static DALGivenAnswer ToDalGivenAnswerFull(this GivenAnswer ga)
        {
            var newGA = ga.ToDalGivenAnswer();
            newGA.Answer = ga.Answer.ToDalAnswerFull();
            newGA.TestResult = ga.TestResult.ToDalTestResult();
            return newGA;
        }
        public static GivenAnswer ToOrmGivenAnswerFull(this DALGivenAnswer ga)
        {
            var newGA = ga.ToOrmGivenAnswer();
            newGA.Answer = ga.Answer.ToOrmAnswer();
            newGA.TestResult = ga.TestResult.ToOrmTestResult();
            return newGA;
        }
        public static DALQuestion ToDalQuestionFull(this Question q)
        {
            var newQ = q.ToDalQuestion();
            newQ.Test = q.Test.ToDalTest();
            foreach (var a in q.Answers)
                newQ.Answers.Add(a.ToDalAnswer());
            return newQ;
        }
        public static Question ToOrmQuestionFull(this DALQuestion q)
        {
            var newQ = q.ToOrmQuestion();
            foreach (var a in q.Answers)
                newQ.Answers.Add(a.ToOrmAnswer());
            return newQ;
        }
        public static DALTest ToDalTestFull(this Test test)
        {
            var newTest = test.ToDalTest();
            foreach (var q in test.Questions)
                newTest.Questions.Add(q.ToDalQuestionFull());
            foreach (var t in test.TestResults)
                newTest.TestResults.Add(t.ToDalTestResult());
            return newTest;
        }
        public static Test ToOrmTestFull(this DALTest test)
        {
            var newTest = test.ToOrmTest();
            foreach (var q in test.Questions)
                newTest.Questions.Add(q.ToOrmQuestionFull());
            return newTest;
        }
        public static DALTestResult ToDalTestResultFull(this TestResult tr)
        {
            var newTR = tr.ToDalTestResult();
            newTR.User = tr.User.ToDalUser();
            newTR.Test = tr.Test.ToDalTestFull();
            foreach (var ga in tr.GivenAnswers)
                newTR.GivenAnswers.Add(ga.ToDalGivenAnswerFull());
            return newTR;
        }
        public static TestResult ToOrmTestResultFull(this DALTestResult tr)
        {
            var newTR = tr.ToOrmTestResult();
            foreach (var ga in tr.GivenAnswers)
                newTR.GivenAnswers.Add(ga.ToOrmGivenAnswer());
            return newTR;
        }
    }
}
