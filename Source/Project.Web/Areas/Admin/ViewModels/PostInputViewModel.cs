namespace Project.Web.Areas.Admin.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Project.Models;

    public class PostInputViewModel : IMapFrom<Post>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(5000)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}