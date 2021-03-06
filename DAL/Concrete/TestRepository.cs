﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class TestRepository : ITestRepository
    {

        private readonly DbContext context;

        public TestRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalTest> GetAll()
        {
            var tests = context.Set<Test>().AsEnumerable();
            return tests.Select(test => new DalTest()
            {
                Id = test.Id,
                Name = test.Name,
                Questions = new List<DalQuestion>()
            });
        }

        public DalTest GetById(int key)
        {
            Test test = context.Set<Test>().FirstOrDefault(t => t.Id == key);
            DalTest dalTest = new DalTest()
                {
                    Id = test.Id,
                    Name = test.Name,
                    Questions = new List<DalQuestion>()
                };
            foreach (var question in test.Questions)
            {
                DalQuestion dalQuestion = new DalQuestion()
                {
                    Id = question.Id,
                    Text = question.Text,
                    Options = new List<DalOption>()
                };
                foreach (var option in question.Options)
                {
                    DalOption dalOption = new DalOption()
                    {
                        Id = option.Id,
                        IsAnswer = option.IsAnswer,
                        QuestionId = option.QuestionId,
                        Text = option.Text
                    };
                    dalQuestion.Options.Add(dalOption);
                }
                dalTest.Questions.Add(dalQuestion);
            }
            return dalTest;
        }

        public DalTest GetByPredicate(Expression<Func<DalTest, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalTest e)
        {
            Test test = new Test()
            {
                Id = e.Id,
                Name = e.Name,
                Questions = new List<Question>()
            };
            foreach (var question in e.Questions)
            {
                Question ormQuestion = context.Set<Question>().FirstOrDefault(m => m.Id == question.Id);
                test.Questions.Add(ormQuestion);
            }
            context.Set<Test>().Add(test);
            context.SaveChanges();
        }

        public void Delete(DalTest e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTest entity)
        {
            Test ormTest = entity.ToOrm();
            Test original = context.Set<Test>().Include(m => m.Questions).Single(m => m.Id == entity.Id);
            
            context.Entry(original).CurrentValues.SetValues(entity);

            foreach (Question dalQuestion in original.Questions.ToList())
            {
                if (ormTest.Questions.All(s => s.Id != dalQuestion.Id))
                    original.Questions.Remove(dalQuestion);
            }

            foreach (Question dalQuestion in ormTest.Questions.ToList())
            {
                var question = original.Questions.FirstOrDefault(s => s.Id == dalQuestion.Id);
                if (question == null)
                {
                    var newQuestion = context.Set<Question>().FirstOrDefault(m => m.Id == dalQuestion.Id);
                    original.Questions.Add(newQuestion);
                }
            }
            context.SaveChanges();
        }
    }
}
