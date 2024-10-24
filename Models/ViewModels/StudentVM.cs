using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LW_1.Models.ViewModels
{
    public class StudentVM
    {
        public System.Guid ID_студента { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Фамилия { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Имя { get; set; }
        public string Отчество { get; set; }
        [Required]
        public bool Пол { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Адрес_проживания { get; set; }
        [DisplayName("Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Дата_рождения { get; set; }
        [Required]
        public string Уровень_владения_ИЯ { get; set; }
    }
}