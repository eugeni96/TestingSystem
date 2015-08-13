using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface ITestService
    {
        TestEntity GetTestByKey(int key);
        IEnumerable<TestEntity> GetAll();
        void Create(TestEntity entity);
        void Delete(TestEntity entity);
        void Update(TestEntity entity);
    }
}
