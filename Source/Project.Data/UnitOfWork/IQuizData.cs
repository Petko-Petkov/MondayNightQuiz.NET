namespace Project.Models.UnitOfWork
{
    using Contracts.Repositories;

    public interface IQuizData
    {
        IDeletableEntityRepository<Comment> Comments { get; }

        IDeletableEntityRepository<Post> Posts { get; }

        IDeletableEntityRepository<Quiz> Quizzes { get; }

        IDeletableEntityRepository<Round> Rounds { get; }

        IDeletableEntityRepository<Question> Question { get; }

        IDeletableEntityRepository<Team> Teams { get; }

        IDeletableEntityRepository<ApplicationUser> Users { get; } 

        void SaveChanges();
    }
}
