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
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();

        public ActionResult Index()
        {
            if (Session["TaiKhoanAdmin"] != null)
            {
                var products = db.SanPham;
                return View(products.ToList());
            }

            return RedirectToAction("Index", "HomePage");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSanpham,IDPhanloai,TenSP,GiaSP,AnhMinhHoa,AnhMinhHoa1,AnhMoTa1,AnhMoTa2,AnhMoTa3," +
            "AnhMoTa4,AnhMoTa5,AnhMoTa6,MoTaSP,ManHinh,HDH,CameraSau,CameraTruoc,Chip,Ram,DungLuong,Sim,Pin")] SanPham sanPham,
           HttpPostedFileBase ImageFile1, HttpPostedFileBase ImageFile2, HttpPostedFileBase ImageFile3, HttpPostedFileBase ImageFile4
           , HttpPostedFileBase ImageFile5, HttpPostedFileBase ImageFile6, HttpPostedFileBase ImageFile7, HttpPostedFileBase ImageFile8)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile1 != null && ImageFile2 != null && ImageFile3 != null && ImageFile4 != null && ImageFile5 != null && ImageFile6 != null && ImageFile7 != null && ImageFile8 != null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName1 = Path.GetFileName(ImageFile1.FileName);
                    var path1 = Path.Combine(Server.MapPath("/Image"), fileName1);
                    ImageFile1.SaveAs(path1);

                    // Upload file 2
                    var fileName2 = Path.GetFileName(ImageFile2.FileName);
                    var path2 = Path.Combine(Server.MapPath("/Image"), fileName2);

                    ImageFile2.SaveAs(path2);
                    // Upload file 3
                    var fileName3 = Path.GetFileName(ImageFile3.FileName);
                    var path3 = Path.Combine(Server.MapPath("/Image"), fileName3);

                    ImageFile3.SaveAs(path3);
                    // Upload file 4
                    var fileName4 = Path.GetFileName(ImageFile4.FileName);
                    var path4 = Path.Combine(Server.MapPath("/Image"), fileName4);

                    ImageFile4.SaveAs(path4);
                    // Upload file 5
                    var fileName5 = Path.GetFileName(ImageFile5.FileName);
                    var path5 = Path.Combine(Server.MapPath("/Image"), fileName5);

                    ImageFile5.SaveAs(path5);
                    // Upload file 6
                    var fileName6 = Path.GetFileName(ImageFile6.FileName);
                    var path6 = Path.Combine(Server.MapPath("/Image"), fileName6);

                    ImageFile6.SaveAs(path6);
                    // Upload file 7
                    var fileName7 = Path.GetFileName(ImageFile7.FileName);
                    var path7 = Path.Combine(Server.MapPath("/Image"), fileName7);

                    ImageFile7.SaveAs(path7);
                    // Upload file 8
                    var fileName8 = Path.GetFileName(ImageFile8.FileName);
                    var path8 = Path.Combine(Server.MapPath("/Image"), fileName8);

                    ImageFile8.SaveAs(path8);


                }
                db.SanPham.Add(sanPham);

                db.SaveChanges();
                return RedirectToAction("Index", "AdminProduct");
            }


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
            return View(sanPham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "IDSanpham,TenSP,GiaSP,AnhMinhHoa,AnhMinhHoa1,AnhMoTa1,AnhMoTa2,AnhMoTa3," +
            "AnhMoTa4,AnhMoTa5,AnhMoTa6,MoTaSP,ManHinh,HDH,CameraSau,CameraTruoc,Chip,Ram,DungLuong,Sim,Pin")] SanPham sanPham
            , HttpPostedFileBase ImageFile1, HttpPostedFileBase ImageFile2, HttpPostedFileBase ImageFile3, HttpPostedFileBase ImageFile4
           , HttpPostedFileBase ImageFile5, HttpPostedFileBase ImageFile6, HttpPostedFileBase ImageFile7, HttpPostedFileBase ImageFile8)
        {
            if (ModelState.IsValid)
            {
                SanPham sanPhamToUpdate = db.SanPham.Find(id);
                sanPhamToUpdate.TenSP = sanPham.TenSP;
                sanPhamToUpdate.GiaSP = sanPham.GiaSP;
                sanPhamToUpdate.AnhMinhHoa = sanPham.AnhMinhHoa;
                sanPhamToUpdate.AnhMinhHoa1 = sanPham.AnhMinhHoa1;
                sanPhamToUpdate.AnhMoTa1 = sanPham.AnhMoTa1;
                sanPhamToUpdate.AnhMoTa2 = sanPham.AnhMoTa2;
                sanPhamToUpdate.AnhMoTa3 = sanPham.AnhMoTa3;
                sanPhamToUpdate.AnhMoTa4 = sanPham.AnhMoTa4;
                sanPhamToUpdate.AnhMoTa5 = sanPham.AnhMoTa5;
                sanPhamToUpdate.AnhMoTa6 = sanPham.AnhMoTa6;
                sanPhamToUpdate.MoTaSP = sanPham.MoTaSP;
                sanPhamToUpdate.ManHinh = sanPham.ManHinh;
                sanPhamToUpdate.HDH = sanPham.HDH;
                sanPhamToUpdate.CameraSau = sanPham.CameraSau;
                sanPhamToUpdate.CameraTruoc = sanPham.CameraTruoc;
                sanPhamToUpdate.Chip = sanPham.Chip;
                sanPhamToUpdate.Ram = sanPham.Ram;
                sanPhamToUpdate.DungLuong = sanPham.DungLuong;
                sanPhamToUpdate.Sim = sanPham.Sim;
                sanPhamToUpdate.Pin = sanPham.Pin;
                if (ImageFile1 != null && ImageFile2 != null && ImageFile3 != null && ImageFile4 != null && ImageFile5 != null && ImageFile6 != null && ImageFile7 != null && ImageFile8 != null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName1 = Path.GetFileName(ImageFile1.FileName);
                    var path1 = Path.Combine(Server.MapPath("/Image"), fileName1);
                    ImageFile1.SaveAs(path1);

                    // Upload file 2
                    var fileName2 = Path.GetFileName(ImageFile2.FileName);
                    var path2 = Path.Combine(Server.MapPath("/Image"), fileName2);

                    ImageFile2.SaveAs(path2);
                    // Upload file 3
                    var fileName3 = Path.GetFileName(ImageFile3.FileName);
                    var path3 = Path.Combine(Server.MapPath("/Image"), fileName3);

                    ImageFile3.SaveAs(path3);
                    // Upload file 4
                    var fileName4 = Path.GetFileName(ImageFile4.FileName);
                    var path4 = Path.Combine(Server.MapPath("/Image"), fileName4);

                    ImageFile4.SaveAs(path4);
                    // Upload file 5
                    var fileName5 = Path.GetFileName(ImageFile5.FileName);
                    var path5 = Path.Combine(Server.MapPath("/Image"), fileName5);

                    ImageFile5.SaveAs(path5);
                    // Upload file 6
                    var fileName6 = Path.GetFileName(ImageFile6.FileName);
                    var path6 = Path.Combine(Server.MapPath("/Image"), fileName6);

                    ImageFile6.SaveAs(path6);
                    // Upload file 7
                    var fileName7 = Path.GetFileName(ImageFile7.FileName);
                    var path7 = Path.Combine(Server.MapPath("/Image"), fileName7);

                    ImageFile7.SaveAs(path7);
                    // Upload file 8
                    var fileName8 = Path.GetFileName(ImageFile8.FileName);
                    var path8 = Path.Combine(Server.MapPath("/Image"), fileName8);

                    ImageFile8.SaveAs(path8);
                    /*//Save vào Images Folder
                    ImagePro.SaveAs(path);
                    db.SaveChanges();*/
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            db.SaveChanges();
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
        public ActionResult Details(int? id)
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