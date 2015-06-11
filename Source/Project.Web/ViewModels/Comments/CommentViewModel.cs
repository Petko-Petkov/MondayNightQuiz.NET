namespace Project.Web.ViewModels.Comments
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Project.Models;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public int TargetId { get; set; }

        public Target Target { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.Author, opt => opt.MapFrom(m => m.Author.UserName));
        }
    }
}