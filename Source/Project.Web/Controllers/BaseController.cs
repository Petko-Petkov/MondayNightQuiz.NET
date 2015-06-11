namespace Project.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Microsoft.AspNet.Identity;

    using Project.Models;
    using Project.Models.UnitOfWork;

    public class BaseController : Controller
    {
        public BaseController(IQuizData data)
        {
            this.Data = data;
        }

        protected ApplicationUser User { get; set; }

        protected IQuizData Data { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.User = this.Data.Users.GetById(requestContext.HttpContext.User.Identity.GetUserId());

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}