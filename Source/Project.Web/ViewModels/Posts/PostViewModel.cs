namespace Project.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Comments;
    using Infrastructure.Mapping;
    using Project.Models;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public DateTime DateCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.Author, opt => opt.MapFrom(a => a.Author.UserName))
                .ForMember(p => p.DateCreated, opt => opt.MapFrom(o => o.CreatedOn));
        }
    }
}