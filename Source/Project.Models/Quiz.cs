namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts.Contracts;

    public class Quiz : DeletableEntity
    {
        public Quiz()
        {
            this.Participants = new HashSet<Team>();
            this.Rounds = new HashSet<Round>();
        }

        [Key]
        public int Id { get; set; }

        public int QuizMasterId { get; set; }

        public virtual Team QuizMaster { get; set; }

        public DateTime DateEvent { get; set; }

        public virtual ICollection<Team> Participants { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }
    }
}
