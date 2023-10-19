using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["TaiKhoanAdmin"] != null)
            {
                var customer = db.KhachHang;
                return View(customer.ToList());
            }
            return RedirectToAction("Login", "LoginRegister");
        }
       
    }
}