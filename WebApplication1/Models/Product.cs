using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int IDSanPham { get; set; }
        public int IDThongSo { get; set; }
        public int IDPhanLoai { get; set; }
        public string TenSP { get; set; }
        public float GiaSP { get; set; }
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
    }
}