namespace Project.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Project.Models.UnitOfWork;
    using ViewModels;

    public class QuizController : BaseController
    {
        public QuizController(IQuizData data)
            :base(data)
        {
        }

        // GET: Quiz
        public ActionResult Index()
        {
            var quizzes =
                base.Data.Quizzes.All().Project().To<QuizViewModel>().OrderByDescending(q => q.DateEvent).Take(10);

            return View(quizzes);
        }

        public ActionResult GetById(int id)
        {
            var quiz = base.Data.Quizzes.All().Project().To<QuizViewModel>().FirstOrDefault(q => q.Id == id);

            return View(quiz);
        }
    }
}