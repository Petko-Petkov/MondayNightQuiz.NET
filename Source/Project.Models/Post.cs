namespace Project.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts.Contracts;

    public class Post : DeletableEntity
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id{ get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(2000)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
