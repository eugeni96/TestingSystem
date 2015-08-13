using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.CompletedTestEntities;

namespace BLL.Interfacies.Services
{
    public interface ITestCompletedService
    {
        void Create(TestCompletedEntity testCompletedEntity);
        ShortTestResultEntity GetShortTestResult(TestCompletedEntity testCompletedEntity);
        TestCompletedEntity GetById(int key);
    }
}
