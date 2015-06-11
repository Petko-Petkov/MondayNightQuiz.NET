namespace Project.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Contracts.Contracts;
    using Contracts.Repositories;
    using Data;
    using Models;
    using Models.UnitOfWork;

    public class QuizData : IQuizData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public QuizData()
            : this(new ApplicationDbContext())
        {
        }

        public QuizData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IDeletableEntityRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IDeletableEntityRepository<Post> Posts
        {
            get { return this.GetRepository<Post>(); }
        }

        public IDeletableEntityRepository<Round> Rounds
        {
            get { return this.GetRepository<Round>(); }
        }

        public IDeletableEntityRepository<Team> Teams
        {
            get { return this.GetRepository<Team>(); }
        }

        public IDeletableEntityRepository<Quiz> Quizzes
        {
            get { return this.GetRepository<Quiz>(); }
        }

        public IDeletableEntityRepository<Question> Question
        {
            get { return this.GetRepository<Question>(); }
        }
        
        public IDeletableEntityRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
