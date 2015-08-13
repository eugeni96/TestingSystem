using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class TestService : ITestService
    {

        private readonly IUnitOfWork uow;
        private readonly ITestRepository testRepository;

        public TestService(IUnitOfWork uow, ITestRepository testRepository)
        {
            this.uow = uow;
            this.testRepository = testRepository;
        }

        public TestEntity GetTestByKey(int key)
        {
            return testRepository.GetById(key).ToBllTest();
        }

        public IEnumerable<TestEntity> GetAll()
        {
            return testRepository.GetAll().Select(test => test.ToBllTest());
        }

        public void Create(TestEntity entity)
        {
            testRepository.Create(entity.ToDalTest());
        }

        public void Delete(TestEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TestEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
