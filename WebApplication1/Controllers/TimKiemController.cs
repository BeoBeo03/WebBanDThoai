using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{

    public class TimKiemController : Controller
    {
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();

        [HttpPost]
        public ActionResult KQTimKiem(FormCollection f)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<SanPham> listKQ = db.SanPham.Where(n => n.TenSP.Contains(sTuKhoa)).ToList();
            
            
            ViewBag.ThongBao1 = "Đã tìm thấy " + listKQ.Count + " kết quả!";
            return View(listKQ);
        }
        [HttpGet]
        public ActionResult KQTimKiem(string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SanPham> listKQ = db.SanPham.Where(n => n.TenSP.Contains(sTuKhoa)).ToList();
            
            if (listKQ.Count == 0)
            {
                ViewBag.ThongBao1 = "Không tìm thấy sản phẩm nào phù hợp.";
                ViewBag.ThongBao2 = "Thử xem một số mẫu giày khác.";
                return View(listKQ);
            }
            ViewBag.ThongBao1 = "Đã tìm thấy " + listKQ.Count + " kết quả!";
            return View(listKQ);
        }
    }
}