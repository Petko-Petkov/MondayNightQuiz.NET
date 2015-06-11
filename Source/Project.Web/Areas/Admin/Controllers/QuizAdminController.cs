namespace Project.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Populators;
    using Project.Models;
    using Project.Models.UnitOfWork;
    using ViewModels;
    using Web.Controllers;

    public class QuizAdminController : BaseController
    {
        private IDropDownListPopulator populator;

        public QuizAdminController(IQuizData data, IDropDownListPopulator populator)
            :base(data)
        {
            this.populator = populator;
        }

        // GET: Admin/Quiz
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var teams = populator.GetTeams();

            var model = new QuizInputViewModel()
            {
                QuizMasterName = populator.GetTeams()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(QuizInputViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var quiz = new Quiz()
                {
                    QuizMasterId = model.QuizMasterId,
                    DateEvent = model.DateEvent 
                };
                // var quiz = Mapper.Map<Quiz>(model);
                this.Data.Quizzes.Add(quiz);
                this.Data.SaveChanges();

                return Redirect("~/Quiz/Index");
            }

            model.QuizMasterName = this.populator.GetTeams();

            return View(model);
        }
    }
}