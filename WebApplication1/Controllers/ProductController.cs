using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();

        // GET: Product
        public ActionResult Index(int id)
        {
            var product = db.SanPham.Find(id);
            return View(product);
        }
        public ActionResult SanPhamTheoPhanLoai(string phanloai)
        {
            // Thực hiện truy vấn SQL để lấy sản phẩm theo phân loại
            List<SanPham> products = db.SanPham.Where(p => p.PhanLoai.TenPhanLoai == phanloai).ToList();

            // Truyền danh sách sản phẩm đã lọc vào view
            return View(products);
        }
    }
}