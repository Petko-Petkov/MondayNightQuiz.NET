namespace Project.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Sanitizer;
    using Project.Models.UnitOfWork;
    using ViewModels;
    using Web.Controllers;

    public class PostController : BaseController
    {
        private ISanitizer sanitizer;

        public PostController(IQuizData data, ISanitizer sanitizer)
            :base(data)
        {
            this.sanitizer = sanitizer;
        }

        // GET: Admin/Post
        public ActionResult Add()
        {
            var model = new PostInputViewModel();

            return View(model);
        }


    }
}