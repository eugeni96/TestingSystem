using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TestId { get; set; }
        public ICollection<OptionEntity> Options { get; set; } 
    }
}
