using LW_1.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LW_1.Models.ViewModels
{
    public partial class CreateCashierVM
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Фамилия { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Имя { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string Отчество { get; set; }
        [Required]
        [DisplayName("Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Дата_рождения { get; set; }
        [Required]
        [StringLength(1)]
        public string Пол { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public CreateCashierVM() { }
        public CreateCashierVM(Сотрудник кассир)
        {
            Фамилия = кассир.Фамилия;
            Имя = кассир.Имя;
            Отчество = кассир.Отчество;
            Дата_рождения = кассир.Дата_рождения;
            Пол = кассир.Пол;
        }
    }

    public partial class CashierVM
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Фамилия { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Имя { get; set; }
        public string Отчество { get; set; }
        [Required]
        [DisplayName("Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Дата_рождения { get; set; }
        [Required]
        public string Пол { get; set; }
        [DisplayName("Номер телефона")]
        public Guid PhoneNumberID { get; set; }
        public string PhoneNumber { get; set; }

        public CashierVM() { }

        public CashierVM(Сотрудник кассир)
        {
            Id = кассир.id_сотрудника;
            Фамилия = кассир.Фамилия;
            Имя = кассир.Имя;
            Отчество = кассир.Отчество;
            Дата_рождения = кассир.Дата_рождения;
            Пол = кассир.Пол;
            PhoneNumberID = кассир.id_телефона;
        }
    }
}