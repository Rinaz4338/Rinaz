//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rinaz
{
    using System;
    using System.Collections.Generic;
    
    public partial class Child
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Child()
        {
            this.krujok_child = new HashSet<krujok_child>();
        }
    
        public int id_child { get; set; }
        public string FIO { get; set; }
        public int age { get; set; }
        public string nomer_school { get; set; }
        public string @class { get; set; }
        public string svid_rojdenia { get; set; }
        public string address { get; set; }
        public string roditeli { get; set; }
        public int id_krujok { get; set; }
        public int id_gruppa { get; set; }
    
        public virtual gruppa gruppa { get; set; }
        public virtual Krujok Krujok { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<krujok_child> krujok_child { get; set; }
    }
}