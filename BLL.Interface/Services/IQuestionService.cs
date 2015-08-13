using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IQuestionService
    {
        IEnumerable<QuestionEntity> GetAll();
        QuestionEntity GetById(int key);
        void Create(QuestionEntity entity);
        void Delete(QuestionEntity entity);
        void Update(QuestionEntity entity);
    }
}
