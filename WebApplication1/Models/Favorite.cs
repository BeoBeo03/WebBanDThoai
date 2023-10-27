using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Favorite
    {
        public int IDYeuThich { get; set; }
        public int IDSanPham { get; set; }
        public int IDUser { get; set; }
        public DateTime NgayThem { get; set; }
    }
   
}