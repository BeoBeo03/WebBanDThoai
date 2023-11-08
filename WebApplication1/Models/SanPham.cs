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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.CTDonHang = new HashSet<CTDonHang>();
            this.ThongKe = new HashSet<ThongKe>();
            this.YeuThich = new HashSet<YeuThich>();
        }
    
        public int IDSanpham { get; set; }
        public Nullable<int> IDPhanloai { get; set; }
        public string TenSP { get; set; }
        public Nullable<int> TongSoLuong { get; set; }
        public Nullable<double> GiaBanDau { get; set; }
        public Nullable<double> GiaSP { get; set; }
        public string AnhMinhHoa { get; set; }
        public string AnhMinhHoa1 { get; set; }
        public string AnhMoTa1 { get; set; }
        public string AnhMoTa2 { get; set; }
        public string AnhMoTa3 { get; set; }
        public string AnhMoTa4 { get; set; }
        public string AnhMoTa5 { get; set; }
        public string AnhMoTa6 { get; set; }
        public string MoTaSP { get; set; }
        public string ManHinh { get; set; }
        public string HDH { get; set; }
        public string CameraSau { get; set; }
        public string CameraTruoc { get; set; }
        public string Chip { get; set; }
        public string Ram { get; set; }
        public string DungLuong { get; set; }
        public string Sim { get; set; }
        public string Pin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHang { get; set; }
        public virtual PhanLoai PhanLoai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongKe> ThongKe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YeuThich> YeuThich { get; set; }
    }
}
