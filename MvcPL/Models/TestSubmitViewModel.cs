using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BLL.Interface.Entities;
using BLL.Interfacies.Entities;

namespace MvcPL.Models
{
    public class TestSubmitViewModel
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public TestViewModel Test { get; set; }
        public ICollection<OptionViewModel> Answers { get; set; }

        private QuestionViewModel currentQuestion;
        public QuestionViewModel CurrentQuestion
        {
            get { return currentQuestion; }
        }

        private int currentQuestionIndex;
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public Boolean IsFinished { get; set; }

        public bool MoveToNextQuestion()
        {
            if (Test.Questions == null || Test.Questions.Count == 0)
                return false;
            if (currentQuestion == null)
            {
                currentQuestion = Test.Questions.First();
            }
            else
            {
                if (currentQuestionIndex >= Test.Questions.Count() - 1)
                {
                    return false;
                }
                currentQuestionIndex++;
                currentQuestion = Test.Questions.ElementAt(currentQuestionIndex);
            }
            return true;
        }
    }
}