using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {

        private readonly IUnitOfWork uow;
        private readonly IQuestionRepository questionRepository;

        public QuestionService(IUnitOfWork uow, IQuestionRepository questionRepository)
        {
            this.uow = uow;
            this.questionRepository = questionRepository;
        }

        public IEnumerable<QuestionEntity> GetAll()
        {
            return questionRepository.GetAll().Select(question => question.ToBllQuestion());
        }

        public QuestionEntity GetById(int key)
        {
            return questionRepository.GetById(key).ToBllQuestion();
        }

        public void Create(QuestionEntity entity)
        {
            questionRepository.Create(entity.ToDalQuestion());
        }

        public void Delete(QuestionEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionEntity entity)
        {
            questionRepository.Update(entity.ToDalQuestion());
        }
    }
}
