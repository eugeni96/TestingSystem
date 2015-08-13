using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class TestCompletedRepository : ITestCompletedRepository
    {

        private readonly DbContext context;

        public TestCompletedRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalTestCompleted> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalTestCompleted GetById(int key)
        {
            return context.Set<CompletedTest>().FirstOrDefault(m => m.Id == key).ToDal();
        }

        public DalTestCompleted GetByPredicate(Expression<Func<DalTestCompleted, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalTestCompleted e)
        {
            CompletedTest completedTest = e.ToOrm();
            User user = context.Set<User>().FirstOrDefault(m => m.Id == e.User.Id);
            List<Option> options = completedTest.Answers
                .Select(answer => context.Set<Option>().FirstOrDefault(m => m.Id == answer.Id)).ToList();
            Test test = context.Set<Test>().FirstOrDefault(m => m.Id == completedTest.Test.Id);
            completedTest.User = user;
            completedTest.Answers = options;
            completedTest.Test = test;
            completedTest.IsFinished = true;
            context.Set<CompletedTest>().Add(completedTest);
            context.SaveChanges();
        }

        public void Delete(DalTestCompleted e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTestCompleted entity)
        {
            throw new NotImplementedException();
        }
    }
}
