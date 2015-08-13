using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class QuestionPickViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TestId { get; set; }
        public bool IsPicked { get; set; }
    }
}