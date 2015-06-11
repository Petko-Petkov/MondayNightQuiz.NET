namespace Project.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts.Contracts;

    public class Question : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(500)]
        public string Answer { get; set; }

        public int QuestionNumber { get; set; }

        public int RoundId { get; set; }

        public virtual Round Round { get; set; }

    }
}
