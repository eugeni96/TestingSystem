using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.CompletedTestEntities;
using MvcPL.Models;

namespace MvcPL.Mappers
{
    public static class ViewMapper 
    {

        public static UserViewModel ToViewModel(this UserEntity userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName
            };
        }

        public static UserEntity ToEntity(this UserViewModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName
            };
        }

        public static OptionViewModel ToViewModel(this OptionEntity optionEntity)
        {
            return new OptionViewModel()
            {
                Id = optionEntity.Id,
                IsAnswer = optionEntity.IsAnswer,
                QuestionId = optionEntity.QuestionId,
                Text = optionEntity.Text
            };
        }


        public static OptionEntity ToEntity(this OptionViewModel optionViewModel)
        {
            return new OptionEntity()
            {
                Id = optionViewModel.Id,
                IsAnswer = optionViewModel.IsAnswer,
                QuestionId = optionViewModel.QuestionId,
                Text = optionViewModel.Text
            };
        }

        public static QuestionViewModel ToViewModel(this QuestionEntity questionEntity)
        {
            QuestionViewModel questionViewModel = new QuestionViewModel()
            {
                Id = questionEntity.Id,
                Options = new Dictionary<string, OptionViewModel>(),
                TestId = questionEntity.TestId,
                Text = questionEntity.Text
            };
            foreach (var optionEntity in questionEntity.Options)
            {
                questionViewModel.Options.Add(new KeyValuePair<string, OptionViewModel>(
                Guid.NewGuid().ToString("N"),
                optionEntity.ToViewModel()));
            }
            return questionViewModel;
        }

        public static QuestionEntity ToEntity(this QuestionViewModel questionViewModel)
        {
            QuestionEntity questionEntity = new QuestionEntity()
            {
                Id = questionViewModel.Id,
                Options = new List<OptionEntity>(),
                Text = questionViewModel.Text,
                TestId = questionViewModel.TestId
            };
            foreach (var valuePair in questionViewModel.Options)
            {
                questionEntity.Options.Add(valuePair.Value.ToEntity());
            }
            return questionEntity;
        }

        public static TestViewModel ToViewModel(this TestEntity testEntity)
        {
            TestViewModel testViewModel = new TestViewModel()
            {
                Id = testEntity.Id,
                Name = testEntity.Name,
                Questions = new List<QuestionViewModel>()
            };
            foreach (QuestionEntity questionEntity in testEntity.Questions)
            {
                testViewModel.Questions.Add(questionEntity.ToViewModel());
            }
            return testViewModel;
        }

        public static TestEntity ToEntity(this TestViewModel testViewModel)
        {
            TestEntity testEntity = new TestEntity()
            {
                Id = testViewModel.Id,
                Name = testViewModel.Name,
                Questions = new List<QuestionEntity>()
            };
            foreach (QuestionViewModel questionViewModel in testViewModel.Questions)
            {
                testEntity.Questions.Add(questionViewModel.ToEntity()); 
            }
            return testEntity;
        }

        public static TestSubmitViewModel ToViewModel(this TestCompletedEntity testCompletedEntity)
        {
            TestSubmitViewModel testSubmitViewModel = new TestSubmitViewModel()
            {
                Answers = new List<OptionViewModel>(),
                DateTimeFinish = testCompletedEntity.DateTimeFinish,
                DateTimeStart = testCompletedEntity.DateTimeStart,
                IsFinished = testCompletedEntity.IsFinished,
                Test = testCompletedEntity.Test.ToViewModel(),
                User = testCompletedEntity.User
            };
            foreach (OptionEntity answer in testCompletedEntity.Answers)
            {
                testSubmitViewModel.Answers.Add(answer.ToViewModel());
            }
            return testSubmitViewModel;
        }

        public static TestCompletedEntity ToEntity(this TestSubmitViewModel testSubmitViewModel)
        {
            TestCompletedEntity testCompletedEntity = new TestCompletedEntity()
            {
                Answers = new List<OptionEntity>(),
                DateTimeFinish = testSubmitViewModel.DateTimeFinish,
                DateTimeStart = testSubmitViewModel.DateTimeStart,
                Id = testSubmitViewModel.Id,
                IsFinished = testSubmitViewModel.IsFinished,
                Test = testSubmitViewModel.Test.ToEntity(),
                User = testSubmitViewModel.User
            };
            foreach (var answer in testSubmitViewModel.Answers)
            {
                testCompletedEntity.Answers.Add(answer.ToEntity());
            }
            return testCompletedEntity;
        }

    }
}