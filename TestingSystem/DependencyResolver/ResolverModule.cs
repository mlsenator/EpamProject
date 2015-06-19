using System.Data.Entity;
using BLL.Interface;
using BLL.Interface.Services;
using BLL.Services;
using BLL.TestHelpers;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM.Models;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<WTSContext>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IAnswerRepository>().To<AnswerRepository>();
            kernel.Bind<IGivenAnswerService>().To<GivenAnswerService>();
            kernel.Bind<IGivenAnswerRepository>().To<GivenAnswerRepository>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IQuestionRepository>().To<QuestionRepository>();
            kernel.Bind<ITestService>().To<TestService>();
            kernel.Bind<ITestRepository>().To<TestRepository>();
            kernel.Bind<ITestResultService>().To<TestResultService>();
            kernel.Bind<ITestResultRepository>().To<TestResultRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ITestHelper>().To<TestHelper>();
            kernel.Bind<IDataContext>().To<WTSContext>().InRequestScope();
        }
    }
}