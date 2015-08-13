using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    static class Mapper
    {

        public static Role ToOrm(this DalRole dalRole)
        {
            return new Role()
            {
                Description = dalRole.Description,
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalRole ToDal(this Role ormRole)
        {
            return new DalRole()
            {
                Description = ormRole.Description,
                Id = ormRole.Id,
                Name = ormRole.Name
            };
        }

        public static User ToOrm(this DalUser dalUser)
        {
            var ormUser = new User()
            {
                Email = dalUser.Email,
                Id = dalUser.Id,
                Name = dalUser.Name,
                Password = dalUser.Password,
                Roles = new List<Role>()
            };
            foreach (var role in dalUser.Roles)
            {
                ormUser.Roles.Add(role.ToOrm());
            }
            return ormUser;
        }

        public static DalUser ToDal(this User ormUser)
        {
            var dalUser = new DalUser()
            {
                Id = ormUser.Id,
                Name = ormUser.Name,
                Password = ormUser.Password,
                Roles = new List<DalRole>()
            };
            foreach (var role in ormUser.Roles)
            {
                dalUser.Roles.Add(role.ToDal());
            }
            return dalUser;
        }

        public static Option ToOrm(this DalOption dalOption)
        {
            return new Option()
            {
                Id = dalOption.Id,
                QuestionId = dalOption.QuestionId,
                IsAnswer = dalOption.IsAnswer,
                Text = dalOption.Text
            };
        }

        public static DalOption ToDal(this Option ormOption)
        {
            return new DalOption()
            {
                Id = ormOption.Id,
                IsAnswer = ormOption.IsAnswer,
                QuestionId = ormOption.QuestionId,
                Text = ormOption.Text
            };
        }

        public static Question ToOrm(this DalQuestion dalQuestion)
        {
            var question = new Question()
            {
                Id = dalQuestion.Id,
                Options = new List<Option>(),
                Text = dalQuestion.Text
            };
            foreach (var dalOption in dalQuestion.Options)
            {
                question.Options.Add(dalOption.ToOrm());
            }
            return question;
        }

        public static DalQuestion ToDal(this Question ormQuestion)
        {
            var question = new DalQuestion()
            {
                Id = ormQuestion.Id,
                Options = new List<DalOption>(),
                Text = ormQuestion.Text
                
            };
            foreach (var option in ormQuestion.Options)
            {
                question.Options.Add(option.ToDal());
            }
            return question;
        }

        public static Test ToOrm(this DalTest dalTest)
        {
            Test test = new Test()
            {
                Id = dalTest.Id,
                Name = dalTest.Name,
                Questions = new List<Question>()
            };
            foreach (DalQuestion dalQuestion in dalTest.Questions)
            {
                test.Questions.Add(dalQuestion.ToOrm());
            }
            return test;
        }

        public static DalTest ToDal(this Test ormTest)
        {
            DalTest dalTest = new DalTest()
            {
                Id = ormTest.Id,
                Name = ormTest.Name,
                Questions = new List<DalQuestion>()
            };
            foreach (Question question in ormTest.Questions)
            {
                dalTest.Questions.Add(question.ToDal());
            }
            return dalTest;
        }

        public static CompletedTest ToOrm(this DalTestCompleted dalTestCompleted)
        {
            CompletedTest ormCompletedTest = new CompletedTest()
            {
                Answers = new List<Option>(),
                DateTimeFinish = dalTestCompleted.DateTimeFinish,
                DateTimeStart = dalTestCompleted.DateTimeStart,
                Id = dalTestCompleted.Id,
                IsFinished = dalTestCompleted.IsFinished,
                Test = dalTestCompleted.Test.ToOrm(),
                User = dalTestCompleted.User.ToOrm()
            };
            foreach (DalOption dalOption in dalTestCompleted.Answers)
            {
                ormCompletedTest.Answers.Add(dalOption.ToOrm());
            }
            return ormCompletedTest;
        }

        public static DalTestCompleted ToDal(this CompletedTest completedTest)
        {
            DalTestCompleted dalTestCompleted = new DalTestCompleted()
            {
                Answers = new List<DalOption>(),
                DateTimeFinish = completedTest.DateTimeFinish,
                DateTimeStart = completedTest.DateTimeStart,
                Id = completedTest.Id,
                IsFinished = completedTest.IsFinished,
                Test = completedTest.Test.ToDal(),
                User = completedTest.User.ToDal()
            };
            foreach (Option answer in completedTest.Answers)
            {
                dalTestCompleted.Answers.Add(answer.ToDal());
            }
            return dalTestCompleted;
        }
    }
}
