namespace Project.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Project.Models.UnitOfWork;
    using ViewModels;
    using ViewModels.Posts;

    public class HomeController : BaseController
    {
        public HomeController(IQuizData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            var posts = base.Data.Posts.All().Project().To<PostViewModel>().ToList();

            return this.View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}