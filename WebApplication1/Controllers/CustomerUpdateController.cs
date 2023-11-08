using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerUpdateController : Controller
    {
        // GET: CustomerUpdate
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] != null)
            {
                var userID = (KhachHang)Session["TaiKhoan"];
                var customer = db.KhachHang.Where(yt => yt.IDUser == userID.IDUser).ToList();
                return View(customer);
            }

            return RedirectToAction("Index", "CustomerUpdate");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang customer = db.KhachHang.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "IDUser,TenKH,GioiTinh,Email,SDT")] KhachHang customer)

        {
            if (ModelState.IsValid)
            {
                KhachHang customerUpdate = db.KhachHang.Find(id);
                customerUpdate.TenKH = customer.TenKH;
                customerUpdate.GioiTinh = customer.GioiTinh;
                customer.SDT = customer.SDT;
                customerUpdate.Email = customer.Email;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            db.SaveChanges();
            return View(customer);
        }
    }
}