using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<CompletedTest> CompletedTests { get; set; } 
    }
}
