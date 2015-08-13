using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalTest : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DalQuestion> Questions { get; set; } 
    }
}
