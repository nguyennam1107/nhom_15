//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhom_15.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Music
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Music()
        {
            this.MusicYours = new HashSet<MusicYour>();
        }
    
        public int IdProduct { get; set; }
        public string TenProduct { get; set; }
        public decimal Gia { get; set; }
        public string Image { get; set; }
        public string Source { get; set; }
        public Nullable<int> TheLoaiId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusicYour> MusicYours { get; set; }
        public virtual TheLoai TheLoai { get; set; }
    }
}
