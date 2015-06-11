namespace Project.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Project.Models;

    public class QuizViewModel : IMapFrom<Quiz>
    {
        public int Id { get; set; }

        public Team QuizMaster { get; set; }

        public DateTime DateEvent { get; set; }

        public ICollection<Team> Participants { get; set; }

        public ICollection<Round> Rounds { get; set; }
    }
}