using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        CNPMNC_lt_1Entities db = new CNPMNC_lt_1Entities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            ViewBag.IDThongso = new SelectList(db.ThongSoKyThuat, "IDThongso", "TenThongSo");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSanpham,IDThongso,IDPhanloai,TenSP,GiaSP,AnhMinhHoa,AnhMoTa1,AnhMoTa2,AnhMoTa3,AnhMoTa4,AnhMoTa5,AnhMoTa6,MoTaSP")] SanPham sanPham,
            HttpPostedFileBase ImagePro)
        {
            if (ModelState.IsValid)
            {
                if (ImagePro != null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName = Path.GetFileName(ImagePro.FileName);
                    //Tạo đường dẫn tới file
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);


                    //Lưu tên
                    sanPham.AnhMinhHoa = fileName;
                    //Save vào Images Folder
                    ImagePro.SaveAs(path);

                }
                db.SanPham.Add(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDV = new SelectList(db.ThongSoKyThuat, "IDThongso", "TenThongSo", sanPham.IDThongso);



            return View(sanPham);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDThongso = new SelectList(db.ThongSoKyThuat, "IDThongso", "TenThongSo");

            return View(sanPham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSanpham,IDThongso,IDPhanloai,TenSP,GiaSP,AnhMinhHoa,AnhMoTa1,AnhMoTa2,AnhMoTa3,AnhMoTa4,AnhMoTa5,AnhMoTa6,MoTaSP")] SanPham sanPham
            , HttpPostedFileBase ImagePro)
        {
            if (ModelState.IsValid)
            {
                if (ImagePro != null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName = Path.GetFileName(ImagePro.FileName);
                    //Tạo đường dẫn tới file
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    //Lưu tên
                    sanPham.AnhMinhHoa = fileName;
                    //Save vào Images Folder
                    ImagePro.SaveAs(path);
                    db.SaveChanges();
                }
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "QLSP");
            }




            ViewBag.IDThongso = new SelectList(db.ThongSoKyThuat, "IDThongso", "TenThongSo");

            return View(sanPham);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: ProductsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}