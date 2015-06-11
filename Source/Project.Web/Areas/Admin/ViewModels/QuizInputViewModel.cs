namespace Project.Web.Areas.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Project.Models;

    public class QuizInputViewModel : IMapFrom<Quiz>
    {
        private DateTime dateEvent;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Дата")]
        public DateTime DateEvent
        {
            get { return this.dateEvent.Date > DateTime.Now ? this.dateEvent.Date : DateTime.Now; }
            set { this.dateEvent = value; }
        }

        [Display(Name = "Куизмастър")]
        [UIHint("DropDownList")]
        public int QuizMasterId { get; set; }

        public IEnumerable<SelectListItem> QuizMasterName { get; set; }
    }
}