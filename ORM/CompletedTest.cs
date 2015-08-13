using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class CompletedTest
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Test Test { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public Boolean IsFinished { get; set; }
        public virtual ICollection<Option> Answers { get; set; }
    }
}
