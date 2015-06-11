namespace Project.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts.Contracts;

    public class Team : DeletableEntity
    {
        public Team()
        {
            this.TeamMembers = new HashSet<ApplicationUser>();
            // this.Rounds = new HashSet<Round>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> TeamMembers { get; set; }

        // public virtual ICollection<Round> Rounds { get; set; } 
    }
}
