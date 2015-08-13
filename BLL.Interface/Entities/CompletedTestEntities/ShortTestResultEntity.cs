using System;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interfacies.Entities.CompletedTestEntities
{
    public class ShortTestResultEntity
    {
        public ShortTestResultEntity()
        {
            QuestionResults = new List<QuestionResultEntity>();
        }
        public string TestName { get; set; }
        public UserEntity User { get; set; }
        public ICollection<QuestionResultEntity> QuestionResults { get; set; } 
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public int RightAnsweredQuestions { get; set; }
        public int Questions { get; set; }

    }
}
