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
    
    public partial class YeuThich
    {
        public int IDYeuThich { get; set; }
        public Nullable<int> IDSanPham { get; set; }
        public Nullable<int> IDUser { get; set; }
        public Nullable<System.DateTime> NgayThem { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
