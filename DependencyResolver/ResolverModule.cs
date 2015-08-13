using System.Data.Entity;
using BLL.Interface;
using BLL.Interface.Services;
using BLL.Interfacies.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;
using Ninject.Modules;
using ORM;

namespace DependencyResolver
{
    public class ResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EntityModel>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<ITestRepository>().To<TestRepository>();
            Bind<ITestCompletedRepository>().To<TestCompletedRepository>();
            Bind<IQuestionRepository>().To<QuestionRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUserService>().To<UserService>();
            Bind<ITestService>().To<TestService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<ITestCompletedService>().To<TestCompletedService>();

        }
    }
}