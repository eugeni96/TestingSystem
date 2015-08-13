using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalTestCompleted : IEntity
    {
        public int Id { get; set; }
        public DalUser User { get; set; }
        public DalTest Test { get; set; }
        public ICollection<DalOption> Answers { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public Boolean IsFinished { get; set; }
    }
}
