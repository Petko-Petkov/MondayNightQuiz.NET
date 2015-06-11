namespace Project.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts.Contracts;

    public class Comment : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Content { get; set; }

        public int TargetId { get; set; }

        public Target Target { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
