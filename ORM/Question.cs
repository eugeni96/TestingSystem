using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Question
    {
        public Question()
        {
            Options = new HashSet<Option>();
            Tests = new HashSet<Test>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
