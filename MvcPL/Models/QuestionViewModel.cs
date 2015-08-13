using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;

namespace MvcPL.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TestId { get; set; }
        public IDictionary<string, OptionViewModel> Options { get; set; } 
    }
}