using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalQuestion : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TestId { get; set; }
        public ICollection<DalOption> Options { get; set; } 
    }
}
