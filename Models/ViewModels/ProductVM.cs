using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LW_1.Models.ViewModels
{
    public class CreateProductVM
    {
        [Required]
        public string Наименование { get; set; }
        public Nullable<int> Количество { get; set; }
        [Required]
        public int Id_категории { get; set; }
        public Nullable<decimal> Цена { get; set; }
    }
}