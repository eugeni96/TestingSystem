using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface ITestRepository : IRepository<DalTest>
    {
    }
}
