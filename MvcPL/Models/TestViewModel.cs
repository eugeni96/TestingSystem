﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<QuestionViewModel> Questions { get; set; } 
    }
}