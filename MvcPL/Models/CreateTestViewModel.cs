﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class CreateTestViewModel
    {
        public TestViewModel Test { get; set; }
        public IList<QuestionPickViewModel> AllQuestions { get; set; } 
    }
}