//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LW_1.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Поставка
    {
        public System.Guid id { get; set; }
        public int Количество { get; set; }
        public int Цена_поставки { get; set; }
        public System.DateTime Дата_поставки { get; set; }
        public long Код_товара { get; set; }
        public System.Guid id_поставщика { get; set; }
    
        public virtual Поставщик Поставщик { get; set; }
        public virtual Товар Товар { get; set; }
    }
}
