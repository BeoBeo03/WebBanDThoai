//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.DonHang = new HashSet<DonHang>();
        }
    
        public int IDUser { get; set; }
        public string TenKH { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public Nullable<int> SDT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
