using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.CompletedTestEntities;
using DAL.Interface.DTO;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            var dalUser = new DalUser()
            {
                Id = userEntity.Id,
                Name = userEntity.UserName,
                Password = userEntity.Password,
                Email = userEntity.Email,
                Roles = new List<DalRole>()
            };
            foreach (var role in userEntity.Roles)
            {
                dalUser.Roles.Add(role.ToDalRole());
            }
            return dalUser;
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            var userEntity = new UserEntity()
            {
                Id = dalUser.Id,
                UserName = dalUser.Name,
                Password = dalUser.Password,
                Email = dalUser.Email,
                Roles = new List<RoleEntity>()
            };
            foreach (var role in dalUser.Roles)
            {
                userEntity.Roles.Add(role.ToBllRole());
            }
            return userEntity;
        }

        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalOption ToDalOption(this OptionEntity optionEntity)
        {
            return new DalOption()
            {
                Id = optionEntity.Id,
                IsAnswer = optionEntity.IsAnswer,
                QuestionId = optionEntity.QuestionId,
                Text = optionEntity.Text
            };
        }

        public static OptionEntity ToBllOption(this DalOption option)
        {
            return new OptionEntity()
            {
                Id = option.Id,
                IsAnswer = option.IsAnswer,
                QuestionId = option.QuestionId,
                Text = option.Text
            };
        }

        public static DalQuestion ToDalQuestion(this QuestionEntity question)
        {
            DalQuestion dalQuestion = new DalQuestion()
            {
                Id = question.Id,
                TestId = question.TestId,
                Text = question.Text,
                Options = new List<DalOption>()
            };
            foreach (var option in question.Options)
            {
                dalQuestion.Options.Add(option.ToDalOption());
            }
            return dalQuestion;
        }

        public static QuestionEntity ToBllQuestion(this DalQuestion question)
        {
            QuestionEntity questionEntity = new QuestionEntity()
            {
                Id = question.Id,
                TestId = question.TestId,
                Text = question.Text,
                Options = new List<OptionEntity>()
            };
            foreach (var dalOption in question.Options)
            {
                questionEntity.Options.Add(dalOption.ToBllOption());
            }
            return questionEntity;
        }

        public static DalTest ToDalTest(this TestEntity testEntity)
        {
            DalTest dalTest = new DalTest()
            {
                Id = testEntity.Id,
                Name = testEntity.Name,
                Questions = new List<DalQuestion>()
            };
            foreach (var questionEntity in testEntity.Questions)
            {
                dalTest.Questions.Add(questionEntity.ToDalQuestion());
            }
            return dalTest;
        }

        public static TestEntity ToBllTest(this DalTest test)
        {
            TestEntity testEntity = new TestEntity()
            {
                Id = test.Id,
                Name = test.Name,
                Questions = new List<QuestionEntity>()
            };
            foreach (var dalQuestion in test.Questions)
            {
                testEntity.Questions.Add(dalQuestion.ToBllQuestion());
            }
            return testEntity;
        }

        public static DalTestCompleted ToDalTestCompleted(this TestCompletedEntity testCompletedEntity)
        {
            DalTestCompleted dalTestCompleted = new DalTestCompleted()
            {
                Answers = new List<DalOption>(),
                DateTimeFinish = testCompletedEntity.DateTimeFinish,
                DateTimeStart = testCompletedEntity.DateTimeStart,
                Id = testCompletedEntity.Id,
                IsFinished = testCompletedEntity.IsFinished,
                Test = testCompletedEntity.Test.ToDalTest(),
                User = testCompletedEntity.User.ToDalUser()
            };
            foreach (OptionEntity answer in testCompletedEntity.Answers)
            {
                dalTestCompleted.Answers.Add(answer.ToDalOption());
            }
            return dalTestCompleted;
        }

        public static TestCompletedEntity ToBllTestCompleted(this DalTestCompleted dalTestCompleted)
        {
            TestCompletedEntity testCompletedEntity = new TestCompletedEntity()
            {
                Answers = new List<OptionEntity>(),
                DateTimeFinish = dalTestCompleted.DateTimeFinish,
                DateTimeStart = dalTestCompleted.DateTimeStart,
                Id = dalTestCompleted.Id,
                IsFinished = dalTestCompleted.IsFinished,
                Test = dalTestCompleted.Test.ToBllTest(),
                User = dalTestCompleted.User.ToBllUser()
            };
            foreach (var answer in dalTestCompleted.Answers)
            {
                testCompletedEntity.Answers.Add(answer.ToBllOption());
            }
            return testCompletedEntity;
        }

    }
}
