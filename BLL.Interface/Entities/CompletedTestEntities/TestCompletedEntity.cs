using System;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interfacies.Entities.CompletedTestEntities
{
    public class TestCompletedEntity
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public TestEntity Test { get; set; }
        public ICollection<OptionEntity> Answers { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public Boolean IsFinished { get; set; }
    }
}
