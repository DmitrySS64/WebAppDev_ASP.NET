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
    
    public partial class Дисконтная_карта
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Дисконтная_карта()
        {
            this.Покупка = new HashSet<Покупка>();
        }
    
        public long Номер_карты { get; set; }
        public int Скидка { get; set; }
        public System.Guid id_телефона { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Покупка> Покупка { get; set; }
        public virtual Телефон Телефон { get; set; }
    }
}
