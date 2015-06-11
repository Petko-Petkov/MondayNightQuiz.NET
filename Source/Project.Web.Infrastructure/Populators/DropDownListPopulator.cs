namespace Project.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Caching;
    using Models.UnitOfWork;

    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IQuizData data;
        private ICacheService cache;

        public DropDownListPopulator(IQuizData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetTeams()
        {
            var teams = this.cache.Get<IEnumerable<SelectListItem>>("teams",
                () =>
                {
                    return this.data.Teams
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                });

            return teams;
        }
    }
}
