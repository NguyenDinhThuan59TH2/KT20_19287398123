//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KT20_19287398123.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiMay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiMay()
        {
            this.Mays = new HashSet<May>();
        }
    
        public string MaLoaiMay { get; set; }
        public string CauHinh { get; set; }
        public decimal GiaTien { get; set; }
        public string Hinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<May> Mays { get; set; }
    }
}
