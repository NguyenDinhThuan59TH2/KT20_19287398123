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
    
    public partial class May
    {
        public string MaM { get; set; }
        public string TenMay { get; set; }
        public string MaLoaiMay { get; set; }
    
        public virtual LoaiMay LoaiMay { get; set; }
    }
}
