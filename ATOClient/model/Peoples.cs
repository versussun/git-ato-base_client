//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATOClient.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Peoples
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Peoples()
        {
            this.period_in_ATO = new HashSet<period_in_ATO>();
            this.UBD_sertificate = new HashSet<UBD_sertificate>();
        }
    
        public int id { get; set; }
        public string fio { get; set; }
        public long inn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<period_in_ATO> period_in_ATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UBD_sertificate> UBD_sertificate { get; set; }
    }
}
