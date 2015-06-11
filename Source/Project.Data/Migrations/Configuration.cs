namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Contracts.Global;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            // TODO Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var directory = AssemblyHelpers.GetDirectoryForAssembly(Assembly.GetExecutingAssembly());
            var roundOne = directory + "/Files/RoundOne.txt";
            var roundThree = directory + "/Files/RoundThree.txt";
            var roundSix = directory + "/Files/RoundSix.txt";

            this.SeedRoles(context);
            this.SeedUser(context);
            this.SeedTeams(context);
            this.SeedQuiz(context);
            this.SeedRoundsAndQuestions(context, roundOne);
            this.SeedRoundsAndQuestions(context, roundThree);
            this.SeedRoundsAndQuestions(context, roundSix);
        }

        private void SeedTeams(ApplicationDbContext context)
        {
            if (context.Teams.Any())
            {
                return;
            }

            context.Teams.Add(new Team(){Name = "Параолимпийци"});
            context.Teams.Add(new Team() { Name = "Блонди" });
            context.Teams.Add(new Team() { Name = "Машина" });
            context.Teams.Add(new Team() { Name = "Диск с кавъри" });
            context.Teams.Add(new Team() { Name = "Мизъри софт" });
            context.Teams.Add(new Team() { Name = "Светулките" });
            context.Teams.Add(new Team() { Name = "Ломоносов" });
            context.Teams.Add(new Team() { Name = "Лошата шефка" });
            context.Teams.Add(new Team() { Name = "Мида" });
            context.SaveChanges();
        }

        private void SeedQuiz(ApplicationDbContext context)
        {
            if (context.Quizzes.Any())
            {
                return;
            }

            var quizMaster = context.Teams.FirstOrDefault(t => t.Name == "Параолимпийци"); 

            context.Quizzes.Add(new Quiz()
            {
                DateEvent = new DateTime(2015, 02, 22),
                QuizMaster = quizMaster
            });

            context.SaveChanges();
        }

        private void SeedRoundsAndQuestions(ApplicationDbContext context, string file)
        {
            if (context.Rounds.Any())
            {
                return;
            }

            using (StreamReader reader = new StreamReader(file))
            {
                var quiz = context.Quizzes.FirstOrDefault();
                Round round = new Round();

                while (!reader.EndOfStream)
                {
                    string name, content;
                    int roundNumber, questionNumer;

                    var line = reader.ReadLine();
                    var info = line.Split('@');
                    if (info[0] == "round")
                    {
                        roundNumber = int.Parse(info[1]);
                        round.Quiz = quiz;
                        round.RoundNumber = roundNumber;
                    } 
                    else if (info[0] == "00")
                    {
                        name = info[1];
                        round.Name = name;
                        context.Rounds.Add(round);
                        context.SaveChanges();
                    }
                    else
                    {
                        questionNumer = int.Parse(info[0]);
                        content = info[1];
                        var question = new Question()
                        {
                            Round = round,
                            Answer = info[2],
                            Content = info[1],
                            QuestionNumber = int.Parse(info[0])
                        };

                        context.Questions.Add(question);
                    }
                }

                context.SaveChanges();
            }
        }

        private void SeedUser(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var admin = new ApplicationUser
                {
                    UserName = "Admin"
                };

                userManager.Create(admin, "password");
                userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRole);
            }

            context.SaveChanges();
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any(r => r.Name == GlobalConstants.AdministratorRole))
            {
                return;
            }

            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdministratorRole));

            context.SaveChanges(); 
            ;
        }
    }
}
