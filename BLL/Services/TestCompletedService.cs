using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.CompletedTestEntities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class TestCompletedService : ITestCompletedService
    {

        private readonly ITestCompletedRepository repository;

        public TestCompletedService(ITestCompletedRepository repository)
        {
            this.repository = repository;
        }

        public void Create(TestCompletedEntity testCompletedEntity)
        {
            repository.Create(testCompletedEntity.ToDalTestCompleted());
        }

        public ShortTestResultEntity GetShortTestResult(TestCompletedEntity testCompletedEntity)
        {
            ShortTestResultEntity shortTestResult = new ShortTestResultEntity()
            {
                TestName = testCompletedEntity.Test.Name,
                DateTimeStart = testCompletedEntity.DateTimeStart,
                DateTimeFinish = testCompletedEntity.DateTimeFinish,
                User = testCompletedEntity.User
            };
            foreach (var questionEntity in testCompletedEntity.Test.Questions)
            {
                QuestionResultEntity questionResult = new QuestionResultEntity()
                {
                    Text = questionEntity.Text
                };
                var answersSet = new HashSet<int>(questionEntity.Options.Where(m => m.IsAnswer).Select(m => m.Id));
                var pickedSet =
                    new HashSet<int>(testCompletedEntity.Answers.Where(m => m.QuestionId == questionEntity.Id).Select(m => m.Id));
                questionResult.IsAnsweredCorrectly = answersSet.SetEquals(pickedSet);
                shortTestResult.QuestionResults.Add(questionResult);
            }
            shortTestResult.Questions = testCompletedEntity.Test.Questions.Count;
            shortTestResult.RightAnsweredQuestions = shortTestResult.QuestionResults.Count(m => m.IsAnsweredCorrectly);
            return shortTestResult;
        }

        public TestCompletedEntity GetById(int key)
        {
            return repository.GetById(key).ToBllTestCompleted();
        }
    }
}
