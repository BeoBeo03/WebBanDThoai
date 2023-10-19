using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();
        public ActionResult Index()
        {
            if (Session["TaiKhoanAdmin"] != null)
            {
                var products = db.SanPham.ToList();
                return View(products);
            }
            return RedirectToAction("Login", "LoginRegister");
        }
    }
}