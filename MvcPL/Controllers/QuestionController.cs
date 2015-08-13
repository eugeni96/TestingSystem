using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using MvcPL.Mappers;
using MvcPL.Models;
using Ninject;

namespace MvcPL.Controllers
{
    public class QuestionController : DefaultController
    {
        //
        // GET: /Question/

        [Inject]
        public IQuestionService QuestionService { get; set; }

        public ActionResult Index()
        {
            List<QuestionViewModel> questionViewModels = QuestionService.GetAll()
                .Select(quest => new QuestionViewModel()
            {
                Id = quest.Id,
                Text = quest.Text
            }).ToList();
            return View(questionViewModels);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(QuestionService.GetById(id).ToViewModel());
        }

        [HttpPost]
        public ActionResult Edit(QuestionViewModel question)
        {
            QuestionService.Update(question.ToEntity());
            return View(question);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuestionViewModel()
            {
                Options = new Dictionary<string, OptionViewModel>()
            });
        }

        public ActionResult Create(QuestionViewModel question)
        {
            QuestionService.Create(question.ToEntity());
            return RedirectToAction("Index","Home");
        }

        public ActionResult AddOption()
        {
            return View("OptionItem", new KeyValuePair<string, OptionViewModel>(
                Guid.NewGuid().ToString("N"),
                new OptionViewModel()));
        }

    }
}
