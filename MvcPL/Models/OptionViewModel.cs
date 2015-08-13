using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class OptionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
        public int QuestionId { get; set; }
        public bool IsPicked { get; set; }
    }
}