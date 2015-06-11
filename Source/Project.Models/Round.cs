namespace Project.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts.Contracts;

    public class Round : DeletableEntity
    {
        public Round()
        {
            this.Questions = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int RoundNumber { get; set; }

        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
