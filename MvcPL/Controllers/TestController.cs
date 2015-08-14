using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.CompletedTestEntities;
using BLL.Interfacies.Services;
using MvcPL.Mappers;
using MvcPL.Models;
using Ninject;

namespace MvcPL.Controllers
{
    public class TestController : DefaultController
    {
        //
        // GET: /Test/
        
        [Inject]
        public ITestService TestService { get; set; }

        [Inject]
        public ITestCompletedService TestCompletedService { get; set; }

        [Inject]
        public IQuestionService QuestionService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (IsCurrentUserInRole("Moderator"))
            {
                TestViewModel test = new TestViewModel();
                CreateTestViewModel createEditTestViewModel = new CreateTestViewModel()
                {
                    Test = test,
                    AllQuestions = QuestionService.GetAll().Select(question => new QuestionPickViewModel()
                    {
                        Id = question.Id,
                        Text = question.Text
                    }).ToList()
                };
                return View(createEditTestViewModel);
            }
            return RedirectToNotFoundPage;
        }

        [HttpPost]
        public ActionResult Create(CreateTestViewModel testViewModel)
        {
            if (IsCurrentUserInRole("Moderator"))
            {
                foreach (var pickViewModel in testViewModel.AllQuestions)
                {
                    if (pickViewModel.IsPicked)
                    {
                        testViewModel.Test.Questions.Add(new QuestionViewModel()
                        {
                            Id = pickViewModel.Id,
                            Text = pickViewModel.Text,
                            Options = new Dictionary<string, OptionViewModel>()
                        });
                    }
                }
                TestService.Create(testViewModel.Test.ToEntity());
                return RedirectToAction("Index", "Home");
            }
            return RedirectToNotFoundPage;
        }

        public ActionResult TestList()
        {
            List<TestViewModel> testViewModels = TestService.GetAll().Select(test => new TestViewModel()
            {
                Id = test.Id,
                Name = test.Name
            }).ToList();        
            return View(testViewModels);
        }

        [HttpGet]
        [Authorize]
        public ActionResult TestPass(int id)
        {
            TestEntity test = TestService.GetTestByKey(id);
            TestSubmitViewModel testSubmit = new TestSubmitViewModel
            {
                Test = test.ToViewModel(),
                User = CurrentUser,
                Answers = new List<OptionViewModel>(),
                DateTimeStart = DateTime.Now
            };
            if (testSubmit.MoveToNextQuestion())
            {
                Session["testSubmit"] = testSubmit;
                return View(testSubmit.CurrentQuestion);
            }
            return Redirect("ErrorPage");
        }

        public ActionResult UpdateQuestion(QuestionViewModel question)
        {
            var testSubmit = Session["testSubmit"] as TestSubmitViewModel;
            foreach (var optionViewModel in question.Options.Where(optionViewModel => optionViewModel.Value.IsPicked))
            {
                testSubmit.Answers.Add(optionViewModel.Value);
            }
            if (!testSubmit.MoveToNextQuestion())
            {
                return RedirectToAction("FinishTest");
            }
            return PartialView("Quiz",testSubmit.CurrentQuestion);
            
        }

        public ActionResult FinishTest()
        {
            TestSubmitViewModel testSubmit = Session["testSubmit"] as TestSubmitViewModel;
            testSubmit.DateTimeFinish = DateTime.Now;
            testSubmit.IsFinished = true;
            TestCompletedService.Create(testSubmit.ToEntity());
            return RedirectToAction("TestResult");
        }

        public ActionResult TestResult()
        {
            TestSubmitViewModel testSubmit = Session["testSubmit"] as TestSubmitViewModel;
            ShortTestResultEntity result = TestCompletedService.GetShortTestResult(testSubmit.ToEntity());
            if (Request.IsAjaxRequest())
            {
                return PartialView(result);
            }
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            if (IsCurrentUserInRole("Moderator"))
            {
                TestViewModel test = TestService.GetTestByKey(id).ToViewModel();
                CreateTestViewModel createEditTestViewModel = new CreateTestViewModel()
                {
                    Test = test,
                    AllQuestions = QuestionService.GetAll().Select(question => new QuestionPickViewModel()
                    {
                        Id = question.Id,
                        Text = question.Text,
                        IsPicked = test.Questions.Any(m => m.Id == question.Id)
                    }).ToList()
                };
                return View(createEditTestViewModel);
            }
            return RedirectToNotFoundPage;
        }

        [HttpPost]
        public ActionResult Edit(CreateTestViewModel testViewModel)
        {
            if (IsCurrentUserInRole("Moderator"))
            {
                foreach (var pickViewModel in testViewModel.AllQuestions)
                {
                    if (pickViewModel.IsPicked)
                    {
                        testViewModel.Test.Questions.Add(new QuestionViewModel()
                        {
                            Id = pickViewModel.Id,
                            Text = pickViewModel.Text,
                            Options = new Dictionary<string, OptionViewModel>()
                        });
                    }
                }
                TestService.Update(testViewModel.Test.ToEntity());
                return RedirectToAction("Index", "Home");
            }
            return RedirectToNotFoundPage;
        }

    }
}
