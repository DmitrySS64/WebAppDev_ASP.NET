using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LW_1.Models.ViewModels
{
    public class GroupVM
    {
        public Guid ID_группы { get; set; }
        [Required]
        [DisplayName("Институт")]
        public System.Guid ID_института { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Наименование { get; set; }
        [Required]
        [Range(1800, 2500)]
        public int Год_поступления { get; set; }
        [Required]
        [Range(0, 10)]
        public int Длительность_обучения { get; set; }
        [Required]
        public int Код_формы_обучения { get; set; }
        [Required]
        public string Код_направления_подготовки { get; set; }
    }

    public class GroupViewOnly
    {
        public Guid ID_группы { get; set; }
        
        [DisplayName("Институт")]
        public string Институт { get; set; }

        public string Наименование { get; set; }
        
        public int Год_поступления { get; set; }

        public int Длительность_обучения { get; set; }

        public string Форма_обучения { get; set; }

        public string Код_направления_подготовки { get; set; }
    }
}