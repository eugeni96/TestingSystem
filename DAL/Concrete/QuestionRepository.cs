using System;
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
    public class QuestionRepository : IQuestionRepository
    {

        private readonly DbContext context;

        public QuestionRepository(DbContext context)
        {
            this.context = context;
        } 

        public IEnumerable<DalQuestion> GetAll()
        {
            List<Question> questions = context.Set<Question>().ToList();
            List<DalQuestion> dalQuestions = new List<DalQuestion>();
            foreach (var question in questions)
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
                dalQuestions.Add(dalQuestion);
            }
            return dalQuestions;
        }

        public DalQuestion GetById(int key)
        {
            Question ormQuestion = context.Set<Question>().FirstOrDefault(x => x.Id == key);
            if (ormQuestion == null)
            {
                return new Question(){Options = new List<Option>()}.ToDal();
            }
            return ormQuestion.ToDal();
        }

        public DalQuestion GetByPredicate(Expression<Func<DalQuestion, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalQuestion e)
        {
            Question question = new Question()
            {
                Text = e.Text,
                Options = new List<Option>()
            };
            foreach (DalOption dalOption in e.Options)
            {
                Option option = new Option()
                {
                    Question = question,
                    IsAnswer = dalOption.IsAnswer,
                    Text = dalOption.Text
                };
                question.Options.Add(option);
            }

            context.Set<Question>().Add(question);
            context.SaveChanges();
        }

        public void Delete(DalQuestion e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalQuestion entity)
        {
//            var original = context.Set<Question>().Find(entity.Id);
//            if (original != null)
//            {
//                context.Entry(original).CurrentValues.SetValues(entity.ToOrm());
//                context.SaveChanges();
//            }

//            var ormQuestion = entity.ToOrm();
//            foreach (var option in ormQuestion.Options)
//            {
//                context.Set<Option>().Attach(option);
//                context.Entry(option).State = EntityState.Modified;
//            }
//            context.Set<Question>().Attach(ormQuestion);
//            context.Entry(ormQuestion).State = EntityState.Modified;
//            context.SaveChanges();


            Question original = context.Set<Question>()
                                        .Include(x => x.Options)
                                        .Single(c => c.Id == entity.Id);

            context.Entry(original).CurrentValues.SetValues(entity);

            foreach (var dalOption in original.Options.ToList())
            {
                if (entity.Options.All(s => s.Id != dalOption.Id))
                    context.Set<Option>().Remove(dalOption);
            }

            foreach (Option dalOption in entity.ToOrm().Options)
            {
                var option = original.Options.SingleOrDefault(s => s.Id == dalOption.Id);
                if (option != null)
                {
                    context.Entry(option).CurrentValues.SetValues(dalOption);
                } 
                else
                {
                    original.Options.Add(dalOption);
                }
                    
            }

            context.SaveChanges();
        }
    }
}
